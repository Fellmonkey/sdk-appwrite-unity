#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Reflection;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Appwrite
{
    /// <summary>
    /// Unity MonoBehaviour wrapper for Appwrite Client with DI support
    /// </summary>
    public class AppwriteManager : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private AppwriteConfig config;
        [SerializeField] private bool initializeOnStart = true;
        [SerializeField] private bool dontDestroyOnLoad = true;
        
        private Client _client;
        private Realtime _realtime;
        private bool _isInitialized;
        
        private readonly Dictionary<Type, object> _services = new();
        
        // Events
        public static event Action<Client> OnClientInitialized;
        public static event Action OnClientDestroyed;
        
        // Singleton instance for easy access
        public static AppwriteManager Instance { get; private set; }
        
        // Properties
        public Client Client 
        { 
            get 
            { 
                if (_client == null)
                    throw new InvalidOperationException("Appwrite client is not initialized. Call Initialize() first.");
                return _client; 
            } 
        }
        
        public Realtime Realtime 
        { 
            get 
            { 
                if (!_realtime)
                    Debug.LogWarning("Realtime was not initialized. Call Initialize(true) to enable it.");
                return _realtime; 
            } 
        }
        
        public bool IsInitialized => _isInitialized;
        public AppwriteConfig Config => config;

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
                if (dontDestroyOnLoad)
                    DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Debug.LogWarning("Multiple AppwriteManager instances detected. Destroying duplicate.");
                Destroy(gameObject);
            }
        }

        private async void Start()
        {
            if (initializeOnStart)
            {
                await Initialize();
            }
        }
        
        /// <summary>
        /// Initialize the Appwrite client and selected services
        /// </summary>
        public async UniTask<bool> Initialize(bool needRealtime = false)
        {
            if (_isInitialized)
            {
                Debug.LogWarning("Appwrite client is already initialized");
                return true;
            }
            
            if (!config)
            {
                Debug.LogError("AppwriteConfig is not assigned!");
                return false;
            }
            
            try
            {
                _client = new Client();
                config.ApplyTo(_client);
                
                InitializeSelectedServices();
                
                if (config.AutoConnect)
                {
                    var pingResult = await _client.Ping();
                    Debug.Log($"Appwrite connected successfully: {pingResult}");
                }
                
                if (needRealtime)
                {
                    InitializeRealtime();
                }
                
                _isInitialized = true;
                OnClientInitialized?.Invoke(_client);
                
                Debug.Log("Appwrite client initialized successfully");
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to initialize Appwrite client: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Initialize selected Appwrite services based on the configuration.
        /// </summary>
        private void InitializeSelectedServices()
        {
            _services.Clear();
            var servicesToInit = config.ServicesToInitialize;
            var serviceNamespace = typeof(Account).Namespace; // Assumes all services are in the same namespace.

            var createServiceMethodInfo = GetType().GetMethod(nameof(CreateService), BindingFlags.NonPublic | BindingFlags.Instance);
            if (createServiceMethodInfo == null)
            {
                Debug.LogError("Critical error: CreateService method not found via reflection.");
                return;
            }

            foreach (AppwriteService serviceEnum in Enum.GetValues(typeof(AppwriteService)))
            {
                if (serviceEnum is AppwriteService.None or AppwriteService.All or AppwriteService.Main or AppwriteService.Others) continue;

                if (!servicesToInit.HasFlag(serviceEnum)) continue;
                
                var typeName = $"{serviceNamespace}.{serviceEnum}, {typeof(Account).Assembly.GetName().Name}";
                var serviceType = Type.GetType(typeName);

                if (serviceType != null)
                {
                    var genericMethod = createServiceMethodInfo.MakeGenericMethod(serviceType);
                    genericMethod.Invoke(this, null);
                }
                else
                {
                    Debug.LogWarning($"Could not find class for service '{typeName}'. Make sure the enum name matches the class name.");
                }
            }
        }

        private void CreateService<T>() where T : class
        {
            var type = typeof(T);
            var constructor = type.GetConstructor(new[] { typeof(Client) });
            if (constructor != null)
            {
                _services.Add(type, constructor.Invoke(new object[] { _client }));
            }
            else
            {
                Debug.LogError($"Could not find a constructor for {type.Name} that accepts a Client object.");
            }
        }
        
        private void InitializeRealtime()
        {
            if (_client == null)
                throw new InvalidOperationException("Client must be initialized before realtime");
                
            if (!_realtime)
            {
                var realtimeGo = new GameObject("AppwriteRealtime");
                realtimeGo.transform.SetParent(transform);
                _realtime = realtimeGo.AddComponent<Realtime>();
                _realtime.Initialize(_client);
            }
        }
        
        /// <summary>
        /// Get an initialized service instance
        /// </summary>
        public T GetService<T>() where T : class
        {
            if (!_isInitialized)
                throw new InvalidOperationException("Client is not initialized. Call Initialize() first.");

            var type = typeof(T);
            if (_services.TryGetValue(type, out var service))
            {
                return (T)service;
            }

            throw new InvalidOperationException($"Service of type {type.Name} was not initialized. Ensure it is selected in the AppwriteConfig asset.");
        }
        
        /// <summary>
        /// Try to get an initialized service instance without throwing an exception.
        /// </summary>
        /// <returns>True if the service was found and initialized, otherwise false.</returns>
        public bool TryGetService<T>(out T service) where T : class
        {
            if (!_isInitialized)
            {
                service = null;
                Debug.LogWarning("AppwriteManager: Cannot get service, client is not initialized.");
                return false;
            }

            var type = typeof(T);
            if (_services.TryGetValue(type, out var serviceObj))
            {
                service = (T)serviceObj;
                return true;
            }

            service = null;
            return false;
        }
        
        public void SetConfig(AppwriteConfig newConfig)
        {
            config = newConfig;
        }
        
        public async UniTask<bool> Reinitialize(AppwriteConfig newConfig = null, bool needRealtime = false)
        {
            config = newConfig ?? config;
            Shutdown();
            return await Initialize(needRealtime);
        }
        
        private void Shutdown()
        {
            _realtime?.Disconnect().Forget();
            if (_realtime?.gameObject != null)
                Destroy(_realtime.gameObject);
            _realtime = null;
            _client = null;
            _isInitialized = false;
            _services.Clear();
            
            OnClientDestroyed?.Invoke();
            Debug.Log("Appwrite client shutdown");
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Shutdown();
                Instance = null;
            }
        }
    }
}
#endif
