using UnityEngine;
using UnityEditor;
using System;
using System.IO;

namespace Appwrite.Editor
{
    public class AppwriteSetupWindow : EditorWindow
    {
        private Vector2 scrollPosition;
        private string statusMessage = "";
        private MessageType statusMessageType = MessageType.Info;

        private void OnEnable()
        {
            titleContent = new GUIContent("Appwrite Setup", "Appwrite SDK Setup");
            minSize = new Vector2(520, 520);
            maxSize = new Vector2(520, 520);
            AppwriteSetupAssistant.RefreshPackageStatus();
        }

        private void OnFocus()
        {
            // Refresh package status when the window gains focus
            AppwriteSetupAssistant.RefreshPackageStatus();
            Repaint();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(20);
            DrawHeader();
            EditorGUILayout.Space(15);
            
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            
            // Status message
            if (!string.IsNullOrEmpty(statusMessage))
            {
                EditorGUILayout.HelpBox(statusMessage, statusMessageType);
                EditorGUILayout.Space(10);
            }
            
            DrawDependenciesSection();
            EditorGUILayout.Space(15);
            
            DrawQuickStartSection();
            EditorGUILayout.Space(15);
            
            DrawActionButtons();
            
            EditorGUILayout.EndScrollView();
            
            EditorGUILayout.Space(10);
            DrawFooter();
        }
        
        private void DrawHeader()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            
            var headerStyle = new GUIStyle(EditorStyles.boldLabel)
            {
                fontSize = 16,
                alignment = TextAnchor.MiddleCenter
            };
            
            EditorGUILayout.LabelField("🚀 Appwrite SDK Setup", headerStyle, GUILayout.ExpandWidth(false));
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.Space(4);
            
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField("Configure your Appwrite SDK for Unity", 
                EditorStyles.centeredGreyMiniLabel, GUILayout.ExpandWidth(false));
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }
        
        private void DrawDependenciesSection()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("📦 Dependencies", EditorStyles.boldLabel);
            
            var missingPackages = !AppwriteSetupAssistant.HasUniTask || !AppwriteSetupAssistant.HasWebSocket;
            if (GUILayout.Button("Install All", GUILayout.Width(100)) && missingPackages)
            {
                InstallAllPackages();
            }
            
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(10);
            
            // UniTask package
            DrawPackageStatus("UniTask", AppwriteSetupAssistant.HasUniTask, 
                "Required for async operations", 
                AppwriteSetupAssistant.InstallUniTask);
            
            EditorGUILayout.Space(5);
            
            // WebSocket package
            DrawPackageStatus("NativeWebSocket", AppwriteSetupAssistant.HasWebSocket,
                "Required for realtime features",
                AppwriteSetupAssistant.InstallWebSocket);
            
            EditorGUILayout.Space(5);
            
            if (!missingPackages)
            {
                EditorGUILayout.HelpBox("✨ All required packages are installed!", MessageType.Info);
            }
            
            EditorGUILayout.EndVertical();
        }
        
        private void DrawPackageStatus(string packageName, bool isInstalled, string description, Action installAction)
        {
            var boxStyle = new GUIStyle(EditorStyles.helpBox)
            {
                padding = new RectOffset(10, 10, 10, 10),
                margin = new RectOffset(5, 5, 0, 0)
            };

            EditorGUILayout.BeginVertical(boxStyle);
            
            // Package name and status
            EditorGUILayout.BeginHorizontal();
            var statusIcon = isInstalled ? "✅" : "⚠️";
            var nameStyle = new GUIStyle(EditorStyles.boldLabel)
            {
                fontSize = 12
            };
            EditorGUILayout.LabelField($"{statusIcon} {packageName}", nameStyle);
            
            if (!isInstalled && GUILayout.Button("Install", GUILayout.Width(100)))
            {
                installAction?.Invoke();
            }
            
            EditorGUILayout.EndHorizontal();
            
            // Description
            if (!isInstalled)
            {
                EditorGUILayout.Space(2);
                var descStyle = new GUIStyle(EditorStyles.miniLabel)
                {
                    wordWrap = true
                };
                EditorGUILayout.LabelField(description, descStyle);
            }
            
            EditorGUILayout.EndVertical();
        }

        private void InstallAllPackages()
        {
            try
            {
                var manifestPath = "Packages/manifest.json";
                string[] lines = File.ReadAllLines(manifestPath);
                var sb = new System.Text.StringBuilder();
                
                bool inserted = false;
                bool needsUpdate = false;
                foreach (string line in lines)
                {
                    sb.AppendLine(line);
                    if (!inserted && line.Trim() == "\"dependencies\": {")
                    {
                        if (!AppwriteSetupAssistant.HasUniTask)
                        {
                            sb.AppendLine("    \"com.cysharp.unitask\": \"https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask\",");
                            needsUpdate = true;
                        }
                        if (!AppwriteSetupAssistant.HasWebSocket)
                        {
                            sb.AppendLine("    \"com.endel.nativewebsocket\": \"https://github.com/endel/NativeWebSocket.git#upm\",");
                            needsUpdate = true;
                        }
                        inserted = true;
                    }
                }

                if (needsUpdate)
                {
                    File.WriteAllText(manifestPath, sb.ToString());
                    ShowMessage("Installing packages...", MessageType.Info);
                    
                    EditorApplication.delayCall += () => {
                        AssetDatabase.Refresh();
                        UnityEditor.PackageManager.Client.Resolve();
                        EditorApplication.delayCall += AppwriteSetupAssistant.RefreshPackageStatus;
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to update manifest.json: {ex.Message}");
                ShowMessage("Failed to install packages. Check console for details.", MessageType.Error);
            }
        }

        private void DrawQuickStartSection()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            
            EditorGUILayout.LabelField("⚡ Quick Start", EditorStyles.boldLabel);
            EditorGUILayout.Space(10);
            
            var allPackagesInstalled = AppwriteSetupAssistant.HasUniTask && AppwriteSetupAssistant.HasWebSocket;
            GUI.enabled = allPackagesInstalled;

            var buttonStyle = new GUIStyle(GUI.skin.button)
            {
                padding = new RectOffset(12, 12, 8, 8),
                margin = new RectOffset(5, 5, 5, 5),
                fontSize = 12
            };

            if (GUILayout.Button("🎮 Setup Current Scene", buttonStyle))
            {
                SetupCurrentScene();
            }

            GUI.enabled = true;

            EditorGUILayout.Space(10);
            var headerStyle = new GUIStyle(EditorStyles.boldLabel)
            {
                fontSize = 11
            };
            EditorGUILayout.LabelField("This will create in the current scene:", headerStyle);
            
            var itemStyle = new GUIStyle(EditorStyles.label)
            {
                richText = true,
                padding = new RectOffset(15, 0, 2, 2),
                fontSize = 11
            };
            
            EditorGUILayout.LabelField("• <b>AppwriteManager</b> - Main SDK manager component", itemStyle);
            EditorGUILayout.LabelField("• <b>AppwriteConfig</b> - Configuration asset for your project", itemStyle);
            EditorGUILayout.LabelField("• <b>Realtime</b> - WebSocket connection handler", itemStyle);

            if (!allPackagesInstalled)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.HelpBox("Please install all required packages first", MessageType.Warning);
            }

            EditorGUILayout.EndVertical();
        }
        
        private void DrawActionButtons()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            
            EditorGUILayout.BeginHorizontal();
            
            var buttonStyle = new GUIStyle(GUI.skin.button)
            {
                padding = new RectOffset(15, 15, 8, 8),
                margin = new RectOffset(5, 5, 5, 5),
                fontSize = 11
            };

            if (GUILayout.Button(new GUIContent(" 📖 Documentation", "Open Appwrite documentation"), buttonStyle))
            {
                Application.OpenURL("https://Appwrite.io/docs");
            }
            
            if (GUILayout.Button(new GUIContent(" 💬 Discord Community", "Join our Discord community"), buttonStyle))
            {
                Application.OpenURL("https://Appwrite.io/discord");
            }
            
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }
        
        private void DrawFooter()
        {
            EditorGUI.DrawRect(GUILayoutUtility.GetRect(0, 1), Color.gray);
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Appwrite SDK for Unity", EditorStyles.centeredGreyMiniLabel);
        }

        private async void SetupCurrentScene()
        {
            try
            {
                ShowMessage("Setting up the scene...", MessageType.Info);

                //WARNING: This code uses reflection to access AppwriteUtilities. CAREFUL with path changes!
                var type = Type.GetType("Appwrite.Utilities.AppwriteUtilities, Appwrite"); 
                if (type == null)
                {
                    ShowMessage("AppwriteUtilities не найден. Убедитесь, что Runtime сборка скомпилирована.", MessageType.Warning);
                    return;
                }

                var method = type.GetMethod("QuickSetup", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                if (method == null)
                {
                    ShowMessage("Метод QuickSetup не найден в AppwriteUtilities.", MessageType.Warning);
                    return;
                }

                var task = method.Invoke(null, null);
                if (task == null)
                {
                    ShowMessage("QuickSetup вернул null.", MessageType.Warning);
                    return;
                }

                dynamic dynamicTask = task;
                var result = await dynamicTask;

                if (result != null)
                {
                    var goProp = result.GetType().GetProperty("gameObject");
                    var go = goProp?.GetValue(result) as GameObject;
                    if (go != null)
                    {
                        Selection.activeGameObject = go;
                        ShowMessage("Scene setup completed successfully!", MessageType.Info);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Setup failed: {ex.Message}", MessageType.Error);
            }
        }


        private void ShowMessage(string message, MessageType type)
        {
            statusMessage = message;
            statusMessageType = type;
            Repaint();
            
            if (type != MessageType.Error)
            {
                EditorApplication.delayCall += () => {
                    System.Threading.Thread.Sleep(5000);
                    if (statusMessage == message)
                    {
                        statusMessage = "";
                        Repaint();
                    }
                };
            }
        }
    }
}
