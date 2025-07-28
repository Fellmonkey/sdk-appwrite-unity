using System;
using UnityEngine;

namespace Appwrite
{
    // Define the service enum with Flags attribute for multi-selection in the inspector
    [Flags]
    public enum AppwriteService
    {
        None = 0,
        Account = 1 << 0,
        Databases = 1 << 1,
        Storage = 1 << 2,
        Functions = 1 << 3,
        Messaging = 1 << 4,
        Sites = 1 << 5,
        Locale = 1 << 6,
        Avatars = 1 << 7,
        Health = 1 << 8,
        Migrations = 1 << 9,
        Tokens = 1 << 10,
        Teams = 1 << 11,
        Users = 1 << 12,
        [Tooltip("Selects all main services: Account, Databases, Storage, Functions, Messaging, Sites")]
        Main = (1 << 6) - 1, // 0-5
        [Tooltip("Selects all other services: Locale, Avatars, Health, Migrations, Tokens, Teams, Users")]
        Others = (1 << 13) - 1 ^ (1 << 6) - 1, // 6-12

        [Tooltip("Selects all available services.")]
        All = ~0
        
    }

    /// <summary>
    /// ScriptableObject configuration for Appwrite client settings
    /// </summary>
    [CreateAssetMenu(fileName = "AppwriteConfig", menuName = "Appwrite/Configuration")]
    public class AppwriteConfig : ScriptableObject
    {
        [Header("Connection Settings")]
        [Tooltip("Endpoint URL for Appwrite API (e.g., https://cloud.Appwrite.io/v1)")]
        [SerializeField] private string endpoint = "https://cloud.Appwrite.io/v1";
        
        [Tooltip("WebSocket endpoint for realtime updates (optional)")]
        [SerializeField] private string realtimeEndpoint = "";
        
        [Tooltip("Enable if using a self-signed SSL certificate")]
        [SerializeField] private bool selfSigned;
        
        [Header("Project Settings")]
        [Tooltip("Your Appwrite project ID")]
        [SerializeField] private string projectId = "";

        [Header("Service Initialization")] 
        [Tooltip("Select which Appwrite services to initialize.")]
        [SerializeField] private AppwriteService servicesToInitialize = AppwriteService.All;
        
        [Header("Advanced Settings")]
        [Tooltip("Dev key (optional). Dev keys allow bypassing rate limits and CORS errors in your development environment. WARNING: Storing dev keys in ScriptableObjects is a security risk. Do not expose this in public repositories. Consider loading from a secure location at runtime for production builds.")]
        [SerializeField] private string devKey = "";

        [Tooltip("Automatically connect to Appwrite on start")]
        [SerializeField] private bool autoConnect;

        public string Endpoint => endpoint;
        public string RealtimeEndpoint => realtimeEndpoint;
        public bool SelfSigned => selfSigned;
        public string ProjectId => projectId;
        public string DevKey => devKey;
        public bool AutoConnect => autoConnect;
        public AppwriteService ServicesToInitialize => servicesToInitialize;

        /// <summary>
        /// Validate configuration settings
        /// </summary>
        private void OnValidate()
        {
            if (string.IsNullOrEmpty(endpoint))
                Debug.LogWarning("AppwriteConfig: Endpoint is required");
            
            if (string.IsNullOrEmpty(projectId))
                Debug.LogWarning("AppwriteConfig: Project ID is required");

            if (!string.IsNullOrEmpty(devKey))
                Debug.LogWarning("AppwriteConfig: Dev Key is set. For security, avoid storing keys directly in assets for production builds.");
        }
        
        
        /// <summary>
        /// Apply this configuration to a client
        /// </summary>
        public void ApplyTo(Client client)
        {
            client.SetEndpoint(endpoint);
            client.SetProject(projectId);

            if (!string.IsNullOrEmpty(realtimeEndpoint))
                client.SetEndPointRealtime(realtimeEndpoint);
                
            client.SetSelfSigned(selfSigned);
            
            if (!string.IsNullOrEmpty(devKey))
                client.SetDevKey(devKey);
        }

        #if UNITY_EDITOR
        [UnityEditor.MenuItem("Appwrite/Create Configuration")]
        public static AppwriteConfig CreateConfiguration()
        {
            var config = CreateInstance<AppwriteConfig>();
            
            if (!System.IO.Directory.Exists("Assets/Appwrite"))
            {
                UnityEditor.AssetDatabase.CreateFolder("Assets", "Appwrite");
            }
            if (!System.IO.Directory.Exists("Assets/Appwrite/Resources"))
            {
                UnityEditor.AssetDatabase.CreateFolder("Assets/Appwrite", "Resources");
            }
            
            string path = "Assets/Appwrite/Resources/AppwriteConfig.asset";
            path = UnityEditor.AssetDatabase.GenerateUniqueAssetPath(path);
                
            UnityEditor.AssetDatabase.CreateAsset(config, path);
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.EditorUtility.FocusProjectWindow();
            UnityEditor.Selection.activeObject = config;

            Debug.Log($"Appwrite configuration created at: {path}");
            
            return config;
        }
        #endif
    }
}