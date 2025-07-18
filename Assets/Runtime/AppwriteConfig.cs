using UnityEngine;

namespace Appwrite
{
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
        
        [Header("Advanced Settings")]
        [Tooltip("API key (optional)")]
        [SerializeField] private string apiKey = "";
        
        [Tooltip("Automatically connect to Appwrite on start")]
        [SerializeField] private bool autoConnect;

        public string Endpoint => endpoint;
        public string RealtimeEndpoint => realtimeEndpoint;
        public bool SelfSigned => selfSigned;
        public string ProjectId => projectId;
        public string ApiKey => apiKey;

        public bool AutoConnect => autoConnect;

        /// <summary>
        /// Validate configuration settings
        /// </summary>
        private void OnValidate()
        {
            if (string.IsNullOrEmpty(endpoint))
                Debug.LogWarning("AppwriteConfig: Endpoint is required");
            
            if (string.IsNullOrEmpty(projectId))
                Debug.LogWarning("AppwriteConfig: Project ID is required");
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
            
            if (!string.IsNullOrEmpty(apiKey))
                client.SetKey(apiKey);
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
