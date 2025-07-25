#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Cysharp.Threading.Tasks;
using UnityEngine;
using NativeWebSocket;

namespace Appwrite
{
    #region Realtime Data Models
    
    // Base class to identify a message type
    internal class RealtimeMessageBase
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    // Generic message structure
    internal class RealtimeMessage<T> : RealtimeMessageBase
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }

    // Specific data models for different message types
    internal class RealtimeErrorData
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    internal class RealtimeConnectedData
    {
        [JsonPropertyName("user")]
        public Dictionary<string, object> User { get; set; }
    }
    
    internal class RealtimeAuthData
    {
        [JsonPropertyName("session")]
        public string Session { get; set; }
    }
    
    /// <summary>
    /// Realtime response event structure
    /// </summary>
    [Serializable]
    public class RealtimeResponseEvent<T>
    {
        [JsonPropertyName("events")]
        public string[] Events { get; set; }
        [JsonPropertyName("channels")]
        public string[] Channels { get; set; }
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }
        [JsonPropertyName("payload")]
        public T Payload { get; set; }
    }
    
    #endregion

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

        public void Initialize(Client client)
        {
            _client = client;
        }

        private void Update()
        {
            // DispatchMessageQueue ensures that WebSocket messages are processed on the main thread.
            // This is crucial for Unity API calls (e.g., modifying GameObjects, UI) from within WebSocket events.
            // Note: This ties message processing to the game's frame rate and Time.timeScale. If the game is paused (Time.timeScale = 0), message processing will also pause.
            #if !UNITY_WEBGL || UNITY_EDITOR
                _webSocket?.DispatchMessageQueue();
            #endif
        }

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
            Debug.Log("[Realtime] WebSocket opened successfully.");
        }

        private void OnWebSocketMessage(byte[] data)
        {
            try
            {
                var message = Encoding.UTF8.GetString(data);
                var baseMessage = JsonSerializer.Deserialize<RealtimeMessageBase>(message, Client.DeserializerOptions);

                switch (baseMessage.Type)
                {
                    case "connected":
                        var connectedMsg = JsonSerializer.Deserialize<RealtimeMessage<RealtimeConnectedData>>(message, Client.DeserializerOptions);
                        HandleConnectedMessage(connectedMsg.Data);
                        break;
                    case "event":
                        var eventMsg = JsonSerializer.Deserialize<RealtimeMessage<RealtimeResponseEvent<Dictionary<string, object>>>>(message, Client.DeserializerOptions);
                        HandleRealtimeEvent(eventMsg.Data);
                        break;
                    case "error":
                        var errorMsg = JsonSerializer.Deserialize<RealtimeMessage<RealtimeErrorData>>(message, Client.DeserializerOptions);
                        HandleErrorMessage(errorMsg.Data);
                        break;
                    case "pong":
                        Debug.Log("[Realtime] Received pong");
                        break;
                    default:
                        Debug.Log($"[Realtime] Unknown message type: {baseMessage.Type}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"[Realtime] Message processing failed: {ex.Message}");
                OnError?.Invoke(ex);
            }
        }

        private void HandleConnectedMessage(RealtimeConnectedData data)
        {
            Debug.Log("[Realtime] Received 'connected' message");
            
            if (data.User == null || data.User.Count == 0)
            {
                Debug.Log("[Realtime] No user found, sending fallback authentication");
                SendFallbackAuthentication();
            }
        }

        private void SendFallbackAuthentication()
        {
            var session = _client.Config.GetValueOrDefault("session");
            
            if (!string.IsNullOrEmpty(session))
            {
                var authMessage = new RealtimeMessage<RealtimeAuthData>
                {
                    Type = "authentication",
                    Data = new RealtimeAuthData { Session = session }
                };

                var json = JsonSerializer.Serialize(authMessage, Client.SerializerOptions);
                _webSocket.SendText(json);
            }
        }

        private void HandleErrorMessage(RealtimeErrorData data)
        {
            OnError?.Invoke(new AppwriteException(data.Message, data.Code));
        }

        private void HandleRealtimeEvent(RealtimeResponseEvent<Dictionary<string, object>> eventData)
        {
            try
            {
                var subscriptionsCopy = _subscriptions.Values.ToArray();
                foreach (var subscription in subscriptionsCopy)
                {
                    if (subscription.Channels.Any(subChannel => eventData.Channels.Contains(subChannel)))
                    {
                        subscription.OnMessage?.Invoke(eventData);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"[Realtime] HandleRealtimeEvent error: {ex.Message}");
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
                throw new AppwriteException("Please set endPointRealtime to connect to the realtime server.");
            }

            var project = _client.Config.GetValueOrDefault("project", "");
            if (string.IsNullOrEmpty(project))
            {
                throw new AppwriteException("Project ID is required to connect to the realtime server.");
            }

            var channelParams = string.Join("&", _channels.Select(c => $"channels[]={Uri.EscapeDataString(c)}"));
            
            var uri = new Uri(realtimeEndpoint); 
            
            var realtimePath = uri.AbsolutePath.TrimEnd('/') + "/realtime";
                        
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
            
            _reconnectAttempts = 0;
        }

        public async UniTask Disconnect()
        {
            await CloseConnection();
        }
        
        private async void OnDestroy()
        {
            await Disconnect();
        }
    }
}
#endif