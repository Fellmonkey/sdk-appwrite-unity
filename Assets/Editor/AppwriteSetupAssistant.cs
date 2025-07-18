using UnityEngine;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using System.Linq;

namespace Appwrite.Editor
{
    /// <summary>
    /// Appwrite SDK Setup Assistant
    /// Automatically handles dependencies and setup
    /// Works even when there are compilation errors due to missing dependencies
    /// </summary>
    [InitializeOnLoad]
    public static class AppwriteSetupAssistant
    {
        private const string UNITASK_PACKAGE_URL = "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask";
        private const string UNITASK_PACKAGE_NAME = "com.cysharp.unitask";
        private const string WEBSOCKET_PACKAGE_URL = "https://github.com/endel/NativeWebSocket.git#upm";
        private const string WEBSOCKET_PACKAGE_NAME = "com.endel.nativewebsocket";
        private const string SETUP_COMPLETED_KEY = "Appwrite_Setup_Completed";
        private const string SHOW_SETUP_DIALOG_KEY = "Appwrite_Show_Setup_Dialog";
        private const string COMPILATION_ERRORS_KEY = "Appwrite_Compilation_Errors";

        private static ListRequest listRequest;
        private static AddRequest addRequest;
        private static bool isInstalling;

        public static bool HasUniTask { get; private set; }
        public static bool HasWebSocket { get; private set; }

        static AppwriteSetupAssistant()
        {
            // Check for compilation errors on startup
            EditorApplication.delayCall += CheckForCompilationErrors;
            EditorApplication.delayCall += CheckDependencies;
        }

        /// <summary>
        /// Checks for compilation errors related to missing dependencies
        /// </summary>
        private static void CheckForCompilationErrors()
        {
            // Check compilation state
            bool hasCompilationErrors = EditorApplication.isCompiling || 
                                       UnityEditorInternal.InternalEditorUtility.inBatchMode;

            // Alternative way - check through console
            if (!hasCompilationErrors)
            {
                // Use reflection to access console messages
                try
                {
                    var consoleWindowType = typeof(EditorWindow).Assembly.GetType("UnityEditor.ConsoleWindow");
                    if (consoleWindowType != null)
                    {
                        var getCountsByTypeMethod = consoleWindowType.GetMethod("GetCountsByType", 
                            System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                        
                        if (getCountsByTypeMethod != null)
                        {
                            var result = (int[])getCountsByTypeMethod.Invoke(null, null);
                            // result[2] - error count
                            hasCompilationErrors = result is { Length: > 2 } && result[2] > 0;
                        }
                    }
                }
                catch (System.Exception)
                {
                    // If reflection failed, use simple check
                    hasCompilationErrors = false;
                }
            }

            if (hasCompilationErrors)
            {
                Debug.LogWarning("Appwrite Setup: Compilation errors detected. Setup window will be shown.");
                EditorPrefs.SetBool(COMPILATION_ERRORS_KEY, true);
                
                // Force show setup window when compilation errors exist
                if (!EditorPrefs.GetBool(SETUP_COMPLETED_KEY, false))
                {
                    EditorApplication.delayCall += ShowSetupWindow;
                }
            }
            else
            {
                EditorPrefs.DeleteKey(COMPILATION_ERRORS_KEY);
            }
        }

        private static void CheckDependencies()
        {
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
                return;

            // If there are compilation errors, prioritize resolving them
            if (EditorPrefs.GetBool(COMPILATION_ERRORS_KEY, false))
            {
                if (!EditorPrefs.GetBool(SETUP_COMPLETED_KEY, false))
                {
                    EditorApplication.delayCall += ShowSetupWindow;
                }
                return;
            }

            // Check if setup was already completed
            if (EditorPrefs.GetBool(SETUP_COMPLETED_KEY, false))
                return;

            // Use EditorApplication.delayCall instead of direct call
            EditorApplication.delayCall += () => {
                if (listRequest != null) return; // Avoid duplicate requests
                
                try
                {
                    listRequest = Client.List();
                    EditorApplication.update += CheckListProgress;
                }
                catch (System.Exception ex)
                {
                    Debug.LogError($"Appwrite Setup: Failed to start package listing - {ex.Message}");
                    
                    // Show a setup window anyway if there's an issue
                    if (!EditorPrefs.GetBool(SHOW_SETUP_DIALOG_KEY, false))
                    {
                        EditorPrefs.SetBool(SHOW_SETUP_DIALOG_KEY, true);
                        EditorApplication.delayCall += ShowSetupWindow;
                    }
                }
            };
        }

        private static void CheckListProgress()
        {
            if (listRequest == null)
            {
                EditorApplication.update -= CheckListProgress;
                return;
            }

            if (!listRequest.IsCompleted)
                return;

            EditorApplication.update -= CheckListProgress;

            try
            {
                if (listRequest.Status == StatusCode.Success)
                {
                    HasUniTask = listRequest.Result.Any(package => package.name == UNITASK_PACKAGE_NAME);
                    HasWebSocket = listRequest.Result.Any(package => package.name == WEBSOCKET_PACKAGE_NAME);

                    // Show a window only if any required package is missing AND a window hasn't been shown yet
                    if (!HasUniTask || !HasWebSocket)
                    {
                        bool dialogShown = EditorPrefs.GetBool(SHOW_SETUP_DIALOG_KEY, false);
                        if (!dialogShown)
                        {
                            EditorPrefs.SetBool(SHOW_SETUP_DIALOG_KEY, true);
                            EditorApplication.delayCall += ShowSetupWindow;
                        }
                    }
                    else
                    {
                        CompleteSetup();
                    }
                }
                else
                {
                    string errorMessage = listRequest.Error?.message ?? "Unknown error";
                    Debug.LogError($"Appwrite Setup: Failed to check dependencies - {errorMessage}");
                    
                    // On request error, show setup window
                    if (!EditorPrefs.GetBool(SHOW_SETUP_DIALOG_KEY, false))
                    {
                        EditorPrefs.SetBool(SHOW_SETUP_DIALOG_KEY, true);
                        EditorApplication.delayCall += ShowSetupWindow;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Appwrite Setup: Exception while processing package list - {ex.Message}");
            }
            finally
            {
                // Clear request reference
                listRequest = null;
            }
        }

        private static void ShowSetupWindow()
        {
            var window = EditorWindow.GetWindow<AppwriteSetupWindow>(true, "Appwrite Setup Assistant");
            window.Show();
            window.Focus();
        }

        public static void InstallUniTask()
        {
            InstallPackage(UNITASK_PACKAGE_URL);
        }

        public static void InstallWebSocket()
        {
            InstallPackage(WEBSOCKET_PACKAGE_URL);
        }

        private static void InstallPackage(string packageUrl)
        {
            if (isInstalling)
            {
                Debug.LogWarning("Appwrite Setup: Another package installation is in progress.");
                return;
            }

            isInstalling = true;
            Debug.Log($"Appwrite Setup: Installing package {packageUrl}...");

            try
            {
                AssetDatabase.StartAssetEditing();
                addRequest = Client.Add(packageUrl);
                EditorApplication.update += WaitForInstallation;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Appwrite Setup: Failed to start package installation - {ex.Message}");
                CompleteInstallation();
            }
        }

        private static void WaitForInstallation()
        {
            if (!addRequest.IsCompleted)
                return;

            EditorApplication.update -= WaitForInstallation;

            if (addRequest.Status == StatusCode.Success)
            {
                Debug.Log("Appwrite Setup: Package installed successfully!");
                RefreshPackageStatus();
            }
            else
            {
                Debug.LogError($"Appwrite Setup: Failed to install package - {addRequest.Error?.message ?? "Unknown error"}");
            }

            CompleteInstallation();
        }

        private static void CompleteInstallation()
        {
            isInstalling = false;
            addRequest = null;
            AssetDatabase.StopAssetEditing();
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Refresh package status by checking installed packages
        /// </summary>
        public static void RefreshPackageStatus()
        {
            try
            {
                var request = Client.List();
                EditorApplication.delayCall += () => {
                    if (request.IsCompleted && request.Status == StatusCode.Success)
                    {
                        HasUniTask = request.Result.Any(package => package.name == UNITASK_PACKAGE_NAME);
                        HasWebSocket = request.Result.Any(package => package.name == WEBSOCKET_PACKAGE_NAME);
                    }
                };
            }
            catch (System.Exception ex)
            {
                Debug.LogWarning($"Appwrite Setup: Could not refresh package status - {ex.Message}");
            }
        }

        private static void CompleteSetup()
        {
            EditorPrefs.SetBool(SETUP_COMPLETED_KEY, true);
            EditorPrefs.SetBool(SHOW_SETUP_DIALOG_KEY, true);

            Debug.Log("Appwrite Setup: Setup completed successfully!");
        }

        [MenuItem("Appwrite/Setup Assistant", priority = 1)]
        public static void ShowSetupAssistant()
        {
            ShowSetupWindow();
        }

        [MenuItem("Appwrite/Reset Setup", priority = 100)]
        public static void ResetSetup()
        {
            EditorPrefs.DeleteKey(SETUP_COMPLETED_KEY);
            EditorPrefs.DeleteKey(SHOW_SETUP_DIALOG_KEY);
            HasUniTask = false;
            HasWebSocket = false;

            Debug.Log("Appwrite Setup: Setup state reset. Restart Unity or recompile scripts to trigger setup again.");

            // Force check dependencies after reset
            EditorApplication.delayCall += CheckDependencies;
        }
    }
}
