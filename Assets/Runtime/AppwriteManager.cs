using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

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
                    InitializeRealtime();
                return _realtime; 
            } 
        }
        
        public bool IsInitialized => _isInitialized;
        public AppwriteConfig Config => config;

        private void Awake()
        {
            // Singleton pattern
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
        /// Initialize the Appwrite client
        /// </summary>
        public async UniTask<bool> Initialize()
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
                
                // Test connection
                if (config.AutoConnect)
                {
                    var pingResult = await _client.Ping();
                    Debug.Log($"Appwrite connected successfully: {pingResult}");
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
        /// Initialize realtime connection
        /// </summary>
        private void InitializeRealtime()
        {
            if (_client == null)
                throw new InvalidOperationException("Client must be initialized before realtime");
                
            if (!_realtime)
            {
                var realtimeGo = new GameObject("AppwriteRealtime");
                _realtime = realtimeGo.AddComponent<Realtime>();
                _realtime.Initialize(_client);
            }
        }
        
        /// <summary>
        /// Get or create a service instance
        /// </summary>
        public T GetService<T>() where T : class, new()
        {
            if (_client == null)
                throw new InvalidOperationException("Client is not initialized");
                
            // Use reflection to create service with client parameter
            var constructors = typeof(T).GetConstructors();
            foreach (var constructor in constructors)
            {
                var parameters = constructor.GetParameters();
                if (parameters.Length == 1 && parameters[0].ParameterType == typeof(Client))
                {
                    return (T)Activator.CreateInstance(typeof(T), _client);
                }
            }
            
            // Fallback to parameterless constructor
            return new T();
        }
        
        /// <summary>
        /// Manually set configuration
        /// </summary>
        public void SetConfig(AppwriteConfig newConfig)
        {
            config = newConfig;
        }
        
        /// <summary>
        /// Reinitialize with new configuration
        /// </summary>
        public async UniTask<bool> Reinitialize(AppwriteConfig newConfig = null)
        {
            config = newConfig ?? config;
            Shutdown();
            return await Initialize();
        }
        
        /// <summary>
        /// Shutdown the client
        /// </summary>
        private void Shutdown()
        {
            _realtime?.Disconnect().Forget();
            if (_realtime?.gameObject != null)
                Destroy(_realtime.gameObject);
            _realtime = null;
            _client = null;
            _isInitialized = false;
            
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
