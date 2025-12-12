#if UNI_TASK
using System;
using System.Collections.Generic;
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
                if (ReferenceEquals(_realtime, null))
                    Debug.LogWarning("Realtime was not initialized. Call Initialize(true) to enable it.");
                return _realtime; 
            } 
        }
        
        public bool IsInitialized => _isInitialized;
        public AppwriteConfig Config => config;

        private void Awake()
        {
            if (ReferenceEquals(Instance, null))
            {
                Instance = this;
                if (dontDestroyOnLoad)
                    DontDestroyOnLoad(gameObject);
            }
            else if (!ReferenceEquals(Instance, this))
            {
                Debug.LogWarning("Multiple AppwriteManager instances detected. Destroying duplicate.");
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if (initializeOnStart)
            {
                Initialize().Forget();
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
            
            // Direct service instantiation - no reflection needed for known service types
            // This is more performant and AOT-friendly than generic reflection
            
            if (servicesToInit.HasFlag(AppwriteService.Account))
                TryCreateService<Account>();
            
            if (servicesToInit.HasFlag(AppwriteService.Databases))
                TryCreateService<Databases>();
            
            if (servicesToInit.HasFlag(AppwriteService.Functions))
                TryCreateService<Functions>();
            
            if (servicesToInit.HasFlag(AppwriteService.Storage))
                TryCreateService<Storage>();
            
            if (servicesToInit.HasFlag(AppwriteService.Avatars))
                TryCreateService<Avatars>();
            
            if (servicesToInit.HasFlag(AppwriteService.Graphql))
                TryCreateService<Graphql>();
            
            if (servicesToInit.HasFlag(AppwriteService.Locale))
                TryCreateService<Locale>();
            
            if (servicesToInit.HasFlag(AppwriteService.Messaging))
                TryCreateService<Messaging>();
            
            if (servicesToInit.HasFlag(AppwriteService.Teams))
                TryCreateService<Teams>();
        }
        
        /// <summary>
        /// Try to create and register a service instance.
        /// </summary>
        private void TryCreateService<T>() where T : Service
        {
            try
            {
                var service = (T)Activator.CreateInstance(typeof(T), _client);
                _services[typeof(T)] = service;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to create service {typeof(T).Name}: {ex.Message}");
            }
        }
        
        private void InitializeRealtime()
        {
            if (_client == null)
                throw new InvalidOperationException("Client must be initialized before realtime");
            if (ReferenceEquals(_realtime, null))
            {
                var realtimeGo = new GameObject("AppwriteRealtime");
                realtimeGo.transform.SetParent(transform);
                _realtime = realtimeGo.AddComponent<Realtime>();
                _realtime.Initialize(_client);
            }
            else
            {
                // Update existing realtime with new client reference
                _realtime.UpdateClient(_client);
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
            if (!ReferenceEquals(_realtime, null))
            {
                _realtime.Disconnect().Forget();
                if (_realtime.gameObject != null)
                    Destroy(_realtime.gameObject);
            }
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
