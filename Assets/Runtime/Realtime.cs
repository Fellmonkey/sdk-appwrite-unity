#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Text.Json;
using Cysharp.Threading.Tasks;
using UnityEngine;
using NativeWebSocket;

namespace Appwrite
{
    /// <summary>
    /// Realtime response event structure
    /// </summary>
    [Serializable]
    public class RealtimeResponseEvent<T>
    {
        public string[] Events { get; set; }
        public string[] Channels { get; set; }
        public long Timestamp { get; set; }
        public T Payload { get; set; }
    }

    /// <summary>
    /// Realtime subscription for Unity
    /// </summary>
    public class RealtimeSubscription
    {
        public string[] Channels { get; internal set; }
        public Action<RealtimeResponseEvent<Dictionary<string, object>>> OnMessage { get; internal set; }
        internal Action OnClose { get; set; }

        /// <summary>
        /// Close this subscription
        /// </summary>
        public void Close()
        {
            OnClose?.Invoke();
        }
    }

    /// <summary>
    /// Realtime connection interface for Unity WebSocket communication
    /// </summary>
    public class Realtime : MonoBehaviour
    {
        private Client _client;
        private WebSocket _webSocket;
        private readonly HashSet<string> _channels = new();
        private readonly Dictionary<int, RealtimeSubscription> _subscriptions = new();
        private int _subscriptionCounter;
        private bool _reconnect = true;
        private int _reconnectAttempts;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _creatingSocket;
        private string _lastUrl;
        private CancellationTokenSource _heartbeatTokenSource;

        public bool IsConnected => _webSocket?.State == WebSocketState.Open;
        public event Action OnConnected;
        public event Action OnDisconnected;
        public event Action<Exception> OnError;

        /// <summary>
        /// Initialize Realtime with a client
        /// </summary>
        public void Initialize(Client client)
        {
            _client = client;
        }

        /// <summary>
        /// Unity Update method for processing WebSocket messages
        /// </summary>
        void Update()
        {
            #if !UNITY_WEBGL || UNITY_EDITOR
            if (_webSocket != null)
            {
                _webSocket.DispatchMessageQueue();
            }
            #endif
        }

        /// <summary>
        /// Subscribe to realtime events
        /// </summary>
        public RealtimeSubscription Subscribe(string[] channels, Action<RealtimeResponseEvent<Dictionary<string, object>>> callback)
        {
            Debug.Log($"[Realtime] Subscribe called for channels: [{string.Join(", ", channels)}]");
            
            var subscriptionId = ++_subscriptionCounter;
            var subscription = new RealtimeSubscription
            {
                Channels = channels,
                OnMessage = callback,
                OnClose = () => CloseSubscription(subscriptionId, channels)
            };

            _subscriptions[subscriptionId] = subscription;
            
            // Add channels to the set
            foreach (var channel in channels)
            {
                _channels.Add(channel);
            }

            Debug.Log($"[Realtime] Total channels now: {_channels.Count}");
            
            // Create socket if needed
            CreateSocket().Forget();

            return subscription;
        }

        private void CloseSubscription(int subscriptionId, string[] channels)
        {
            _subscriptions.Remove(subscriptionId);

            // Remove channels that are no longer in use
            foreach (var channel in channels)
            {
                bool stillInUse = _subscriptions.Values.Any(s => s.Channels.Contains(channel));
                if (!stillInUse)
                {
                    _channels.Remove(channel);
                }
            }

            // Recreate socket with new channels or close if none
            if (_channels.Count > 0)
            {
                CreateSocket().Forget();
            }
            else
            {
                CloseConnection().Forget();
            }
        }

        private async UniTask CreateSocket()
        {
            if (_creatingSocket || _channels.Count == 0) return;
            _creatingSocket = true;
            
            Debug.Log($"[Realtime] Creating socket for {_channels.Count} channels");

            try
            {
                var uri = PrepareUri();
                Debug.Log($"[Realtime] Connecting to URI: {uri}");
                
                if (_webSocket == null || _webSocket.State == WebSocketState.Closed)
                {
                    _webSocket = new WebSocket(uri);
                    _lastUrl = uri;
                    SetupWebSocketEvents();
                }
                else if (_lastUrl != uri && _webSocket.State != WebSocketState.Closed)
                {
                    await CloseConnection();
                    _webSocket = new WebSocket(uri);
                    _lastUrl = uri;
                    SetupWebSocketEvents();
                }

                if (_webSocket.State == WebSocketState.Connecting || _webSocket.State == WebSocketState.Open)
                {
                    Debug.Log($"[Realtime] Socket already connecting/connected: {_webSocket.State}");
                    _creatingSocket = false;
                    return;
                }

                Debug.Log("[Realtime] Attempting to connect...");
                await _webSocket.Connect();
                Debug.Log("[Realtime] Connect call completed");
                _reconnectAttempts = 0;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[Realtime] Connection failed: {ex.Message}");
                OnError?.Invoke(ex);
                Retry();
            }
            finally
            {
                _creatingSocket = false;
            }
        }

        private void SetupWebSocketEvents()
        {
            _webSocket.OnOpen += OnWebSocketOpen;
            _webSocket.OnMessage += OnWebSocketMessage;
            _webSocket.OnError += OnWebSocketError;
            _webSocket.OnClose += OnWebSocketClose;
        }

        private void OnWebSocketOpen()
        {
            _reconnectAttempts = 0;
            OnConnected?.Invoke();
            StartHeartbeat();
            Debug.Log($"[Realtime] WebSocket opened successfully: {_lastUrl}");
            
            // Send a test ping immediately to check if we can send/receive
            try
            {
                var testPing = new { type = "ping" };
                var json = JsonSerializer.Serialize(testPing, Client.SerializerOptions);
                _webSocket.SendText(json);
                Debug.Log("[Realtime] Sent test ping immediately after connection");
            }
            catch (Exception ex)
            {
                Debug.LogError($"[Realtime] Failed to send test ping: {ex.Message}");
            }
        }

        private void OnWebSocketMessage(byte[] data)
        {
            try
            {
                var message = Encoding.UTF8.GetString(data);
                Debug.Log($"[Realtime] Raw message: {message}"); // Debug incoming messages
                
                Dictionary<string, object> response;
                try
                {
                    response = JsonSerializer.Deserialize<Dictionary<string, object>>(message, Client.DeserializerOptions);
                }
                catch (Exception jsonEx)
                {
                    Debug.LogError($"[Realtime] JSON deserialization failed: {jsonEx.Message}");
                    return;
                }
                
                if (response.TryGetValue("type", out var typeObj))
                {
                    var messageType = typeObj?.ToString();
                    Debug.Log($"[Realtime] Message type: {messageType}"); // Debug message type
                    
                    switch (messageType)
                    {
                        case "connected":
                            HandleConnectedMessage(response);
                            break;
                        case "event":
                            HandleRealtimeEvent(response);
                            break;
                        case "error":
                            HandleErrorMessage(response);
                            break;
                        case "pong":
                            Debug.Log("[Realtime] Received pong");
                            break;
                        default:
                            Debug.Log($"[Realtime] Unknown message type: {messageType}");
                            break;
                    }
                }
                else
                {
                    Debug.LogWarning("[Realtime] Message has no 'type' field");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"[Realtime] Message processing failed: {ex.Message}");
                OnError?.Invoke(ex);
            }
        }

        private void HandleConnectedMessage(Dictionary<string, object> response)
        {
            Debug.Log("[Realtime] Received 'connected' message");
            
            // Handle authentication if no user is present
            if (response.TryGetValue("data", out var dataObj))
            {
                Dictionary<string, object> data;
                if (dataObj is JsonElement dataElement)
                {
                    data = JsonSerializer.Deserialize<Dictionary<string, object>>(dataElement.GetRawText(), Client.DeserializerOptions);
                }
                else if (dataObj is Dictionary<string, object> dict)
                {
                    data = dict;
                }
                else
                {
                    Debug.LogWarning("[Realtime] Unexpected data type in connected message");
                    return;
                }

                var hasUser = data.TryGetValue("user", out var userObj) && 
                             userObj != null && 
                             (userObj is not JsonElement userElement || !userElement.ValueKind.Equals(JsonValueKind.Null));

                Debug.Log($"[Realtime] Has user: {hasUser}");
                             
                if (!hasUser)
                {
                    Debug.Log("[Realtime] No user found, sending fallback authentication");
                    SendFallbackAuthentication();
                }
            }
        }

        private void SendFallbackAuthentication()
        {
            var session = _client.Config.GetValueOrDefault("session");
            
            if (!string.IsNullOrEmpty(session))
            {
                var authMessage = new
                {
                    type = "authentication",
                    data = new { session }
                };

                var json = JsonSerializer.Serialize(authMessage, Client.SerializerOptions);
                _webSocket.SendText(json);
            }
        }

        private void HandleErrorMessage(Dictionary<string, object> response)
        {
            if (response.TryGetValue("data", out var dataObj))
            {
                Dictionary<string, object> data;
                if (dataObj is JsonElement dataElement)
                {
                    data = JsonSerializer.Deserialize<Dictionary<string, object>>(dataElement.GetRawText(), Client.DeserializerOptions);
                }
                else if (dataObj is Dictionary<string, object> dict)
                {
                    data = dict;
                }
                else
                {
                    Debug.LogWarning("[Realtime] Unexpected data type in error message");
                    return;
                }

                var message = data.TryGetValue("message", out var msgObj) ? msgObj?.ToString() : "Unknown realtime error";
                var code = data.TryGetValue("code", out var codeObj) ? Convert.ToInt32(codeObj.ToString()) : 0;
                
                OnError?.Invoke(new AppwriteException(message, code));
            }
        }

        private void HandleRealtimeEvent(Dictionary<string, object> response)
        {
            Debug.Log("[Realtime] HandleRealtimeEvent called");
            try
            {
                if (response.TryGetValue("data", out var dataObj))
                {
                    Debug.Log($"[Realtime] Data object type: {dataObj.GetType()}");
                    
                    Dictionary<string, object> data;
                    if (dataObj is JsonElement dataElement)
                    {
                        Debug.Log("[Realtime] Data is JsonElement, deserializing...");
                        data = JsonSerializer.Deserialize<Dictionary<string, object>>(dataElement.GetRawText(), Client.DeserializerOptions);
                    }
                    else if (dataObj is Dictionary<string, object> dict)
                    {
                        Debug.Log("[Realtime] Data is already Dictionary");
                        data = dict;
                    }
                    else
                    {
                        Debug.LogError($"[Realtime] Unexpected data type: {dataObj.GetType()}");
                        return;
                    }
                    
                    string[] channels;
                    if (data.TryGetValue("channels", out var channelsObj))
                    {
                        if (channelsObj is JsonElement channelsElement)
                        {
                            channels = JsonSerializer.Deserialize<string[]>(channelsElement.GetRawText());
                        }
                        else if (channelsObj is string[] channelsArray)
                        {
                            channels = channelsArray;
                        }
                        else
                        {
                            // Try to parse as JSON array from the object
                            try
                            {
                                var channelsJson = JsonSerializer.Serialize(channelsObj);
                                channels = JsonSerializer.Deserialize<string[]>(channelsJson);
                            }
                            catch
                            {
                                channels = Array.Empty<string>();
                            }
                        }
                    }
                    else
                    {
                        channels = Array.Empty<string>();
                    }

                    string[] events;
                    if (data.TryGetValue("events", out var eventsObj))
                    {
                        if (eventsObj is JsonElement eventsElement)
                        {
                            events = JsonSerializer.Deserialize<string[]>(eventsElement.GetRawText());
                        }
                        else if (eventsObj is string[] eventsArray)
                        {
                            events = eventsArray;
                        }
                        else
                        {
                            // Try to parse as JSON array from the object
                            try
                            {
                                var eventsJson = JsonSerializer.Serialize(eventsObj);
                                events = JsonSerializer.Deserialize<string[]>(eventsJson);
                            }
                            catch
                            {
                                events = Array.Empty<string>();
                            }
                        }
                    }
                    else
                    {
                        events = Array.Empty<string>();
                    }
                    
                    // Timestamp can be either a string (ISO format) or a number
                    long timestamp = 0;
                    if (data.TryGetValue("timestamp", out var timestampObj))
                    {
                        if (timestampObj is string timestampStr)
                        {
                            if (DateTime.TryParse(timestampStr, out var dt))
                            {
                                timestamp = ((DateTimeOffset)dt).ToUnixTimeMilliseconds();
                            }
                        }
                        else if (timestampObj is JsonElement timestampElement)
                        {
                            if (timestampElement.ValueKind == JsonValueKind.String)
                            {
                                if (DateTime.TryParse(timestampElement.GetString(), out var dt))
                                {
                                    timestamp = ((DateTimeOffset)dt).ToUnixTimeMilliseconds();
                                }
                            }
                            else if (timestampElement.ValueKind == JsonValueKind.Number)
                            {
                                timestamp = timestampElement.GetInt64();
                            }
                        }
                        else
                        {
                            try
                            {
                                timestamp = Convert.ToInt64(timestampObj);
                            }
                            catch
                            {
                                // If conversion fails, keep timestamp as 0
                            }
                        }
                    }
                    
                    Dictionary<string, object> payload;
                    if (data.TryGetValue("payload", out var payloadObj))
                    {
                        if (payloadObj is JsonElement payloadElement)
                        {
                            payload = JsonSerializer.Deserialize<Dictionary<string, object>>(payloadElement.GetRawText(), Client.DeserializerOptions);
                        }
                        else if (payloadObj is Dictionary<string, object> payloadDict)
                        {
                            payload = payloadDict;
                        }
                        else
                        {
                            // Try to parse as JSON object
                            try
                            {
                                var payloadJson = JsonSerializer.Serialize(payloadObj);
                                payload = JsonSerializer.Deserialize<Dictionary<string, object>>(payloadJson, Client.DeserializerOptions);
                            }
                            catch
                            {
                                payload = new Dictionary<string, object>();
                            }
                        }
                    }
                    else
                    {
                        payload = new Dictionary<string, object>();
                    }

                    Debug.Log($"[Realtime] Parsed channels: [{string.Join(", ", channels)}]");
                    Debug.Log($"[Realtime] Parsed events: [{string.Join(", ", events)}]");
                    Debug.Log($"[Realtime] Parsed payload: {JsonSerializer.Serialize(payload)}");

                    var eventResponse = new RealtimeResponseEvent<Dictionary<string, object>>
                    {
                        Events = events,
                        Channels = channels,
                        Timestamp = timestamp,
                        Payload = payload
                    };

                    Debug.Log($"[Realtime] Current subscriptions count: {_subscriptions.Count}");
                    
                    // Create a copy of subscriptions to avoid collection modification issues
                    var subscriptionsCopy = _subscriptions.Values.ToArray();
                    foreach (var subscription in subscriptionsCopy)
                    {
                        Debug.Log($"[Realtime] Checking subscription channels: [{string.Join(", ", subscription.Channels)}]");
                        foreach (var channel in channels)
                        {
                            if (subscription.Channels.Contains(channel))
                            {
                                Debug.Log($"[Realtime] Invoking callback for channel: {channel}");
                                subscription.OnMessage?.Invoke(eventResponse);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogWarning("[Realtime] No 'data' field in event message");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"[Realtime] HandleRealtimeEvent error: {ex.Message}");
                Debug.LogError($"[Realtime] HandleRealtimeEvent stack trace: {ex.StackTrace}");
                OnError?.Invoke(ex);
            }
        }

        private void OnWebSocketError(string error)
        {
            Debug.LogError($"[Realtime] WebSocket error: {error}");
            OnError?.Invoke(new AppwriteException($"WebSocket error: {error}"));
            Retry();
        }

        private void OnWebSocketClose(WebSocketCloseCode closeCode)
        {
            Debug.Log($"[Realtime] WebSocket closed with code: {closeCode}");
            StopHeartbeat();
            OnDisconnected?.Invoke();
            if (_reconnect && closeCode != WebSocketCloseCode.PolicyViolation)
            {
                Retry();
            }
        }

        private void StartHeartbeat()
        {
            StopHeartbeat();
            _heartbeatTokenSource = new CancellationTokenSource();
            
            UniTask.Create(async () =>
            {
                try
                {
                    while (!_heartbeatTokenSource.Token.IsCancellationRequested && _webSocket?.State == WebSocketState.Open)
                    {
                        await UniTask.Delay(TimeSpan.FromSeconds(20), cancellationToken: _heartbeatTokenSource.Token);
                        
                        if (_webSocket?.State == WebSocketState.Open && !_heartbeatTokenSource.Token.IsCancellationRequested)
                        {
                            var pingMessage = new { type = "ping" };
                            var json = JsonSerializer.Serialize(pingMessage, Client.SerializerOptions);
                            await _webSocket.SendText(json);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Expected when cancellation is requested
                }
                catch (Exception ex)
                {
                    OnError?.Invoke(ex);
                }
            });
        }

        private void StopHeartbeat()
        {
            _heartbeatTokenSource?.Cancel();
            _heartbeatTokenSource?.Dispose();
            _heartbeatTokenSource = null;
        }

        private void Retry()
        {
            if (!_reconnect) return;
            
            _reconnectAttempts++;
            var timeout = GetTimeout();
            
            Debug.Log($"Reconnecting in {timeout} seconds.");
            
            UniTask.Create(async () =>
            {
                await UniTask.Delay(TimeSpan.FromSeconds(timeout));
                await CreateSocket();
            });
        }

        private int GetTimeout()
        {
            return _reconnectAttempts < 5 ? 1 :
                   _reconnectAttempts < 15 ? 5 :
                   _reconnectAttempts < 100 ? 10 : 60;
        }

        private string PrepareUri()
        {
            var realtimeEndpoint = _client.Config.GetValueOrDefault("endpointRealtime");
            if (string.IsNullOrEmpty(realtimeEndpoint))
            {
                throw new AppwriteException("Please set endPointRealtime to connect to realtime server");
            }

            var project = _client.Config.GetValueOrDefault("project", "");
            
            // Format channels as separate query parameters like Flutter does
            var channelParams = string.Join("&", _channels.Select(c => $"channels[]={Uri.EscapeDataString(c)}"));
            
            var uri = new Uri(realtimeEndpoint);
            var realtimePath = uri.AbsolutePath.TrimEnd('/') + "/realtime";
            
            // Don't manually add port - let Uri handle it like Flutter does
            var baseUrl = $"{uri.Scheme}://{uri.Host}";
            if ((uri.Scheme == "wss" && uri.Port != 443) || (uri.Scheme == "ws" && uri.Port != 80))
            {
                baseUrl += $":{uri.Port}";
            }
            
            return $"{baseUrl}{realtimePath}?project={Uri.EscapeDataString(project)}&{channelParams}";
        }

        private async UniTask CloseConnection()
        {
            _reconnect = false;
            StopHeartbeat();
            _cancellationTokenSource?.Cancel();
            
            if (_webSocket != null)
            {
                await _webSocket.Close();
            }
            
            _lastUrl = null;
            _reconnectAttempts = 0;
        }

        /// <summary>
        /// Disconnect from realtime
        /// </summary>
        public async UniTask Disconnect()
        {
            await CloseConnection();
        }
        
        /// <summary>
        /// Unity OnDestroy method for cleanup
        /// </summary>
        private async void OnDestroy()
        {
            await Disconnect();
        }
    }
}
#endif