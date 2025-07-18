# Unofficial [Appwrite](https://github.com/appwrite/appwrite) Unity SDK

![Version](https://img.shields.io/badge/api%20version-1.7.4-blue.svg?style=flat-square)
![Unity](https://img.shields.io/badge/Unity-2021.3+-blue.svg)
![License](https://img.shields.io/github/license/fellmonkey/sdk-appwrite-unity.svg?style=flat-square)

**This SDK is compatible with Appwrite server version 1.7.x.**

Appwrite is an open-source backend-as-a-service that abstracts and simplifies complex development tasks behind a simple REST API. The Unity SDK allows you to easily integrate your Unity app with Appwrite, providing access to authentication, databases, storage, real-time features, and more.

Use this SDK to quickly connect your Unity project to Appwrite and interact with all backend APIs and tools. For full API documentation and tutorials, visit: https://appwrite.io/docs


## Installation

### Unity Package Manager (UPM)

1. Open Unity and go to **Window > Package Manager**
2. Click the **+** button and select **Add package from git URL**
3. Enter the following URL: 
```
https://github.com/fellmonkey/sdk-appwrite-unity.git?path=Assets
```
4. Click **Add**
5. In Unity, open the **Appwrite → Setup Assistant** menu and install the required dependencies

### Manual Installation

1. Download the latest release from [GitHub](/releases) or zip
2. Import the Unity package into your project
3. In Unity, open the **Appwrite → Setup Assistant** menu and install the required dependencies

## Dependencies


This SDK requires the following Unity packages and libraries:

- [**UniTask**](https://github.com/Cysharp/UniTask): For async/await support in Unity
- [**NativeWebSocket**](https://github.com/endel/NativeWebSocket): For WebSocket real-time subscriptions
- **System.Text.Json**: For JSON serialization (provided as a DLL in the project)

You can also install UniTask and other required dependencies automatically via **Appwrite → Setup Assistant** in Unity.

## Quick Start

### Example: Unity Integration - Using AppwriteManager

```csharp
    [SerializeField] private AppwriteConfig config;
    private AppwriteManager _manager;

    private async UniTask ExampleWithManager()
    {
        // Get or create manager
        _manager = AppwriteManager.Instance ?? new GameObject("AppwriteManager").AddComponent<AppwriteManager>();
        _manager.SetConfig(config);

        // Initialize
        var success = await _manager.Initialize();
        if (!success) { Debug.LogError("Failed to initialize AppwriteManager"); return; }

        // Direct client access
        var client = _manager.Client;
        var pingResult = await client.Ping();
        Debug.Log($"Ping result: {pingResult}");

        // Service creation through DI container
        var account = _manager.GetService<Account>();
        var databases = _manager.GetService<Databases>();
                
        // Realtime example
        var realtime = _manager.Realtime;
        var subscription = realtime.Subscribe(
            new[] { "databases.*.collections.*.documents" },
            response => Debug.Log($"Realtime event: {response.Events[0]}")
        );
    }
```

### Example: Unity Integration - Using Client directly

```csharp
    [SerializeField] private AppwriteConfig config;

    private async UniTask ExampleWithManager()
    {
        // Create and configure client
        var client = new Client()
            .SetEndpoint(config.Endpoint)
            .SetProject(config.ProjectId);
                    
        if (!string.IsNullOrEmpty(config.ApiKey))
            client.SetKey(config.ApiKey);
                    
        if (!string.IsNullOrEmpty(config.RealtimeEndpoint))
            client.SetEndPointRealtime(config.RealtimeEndpoint);
                
        // Test connection
        var pingResult = await client.Ping();
        Debug.Log($"Direct client ping: {pingResult}");
                
        // Create services manually
        var account = new Account(client);
        var databases = new Databases(client);
                
        // Realtime example
        // You need to create a Realtime instance manually or attach dependently
        realtime.Initialize(client);
        var subscription = realtime.Subscribe(
            new[] { "databases.*.collections.*.documents" },
            response => Debug.Log($"Realtime event: {response.Events[0]}")
        );
    }
```
### Error Handling
```csharp
try
{
    var result = await client..Async();
}
catch (AppwriteException ex)
{
    Debug.LogError($"Appwrite Error: {ex.Message}");
    Debug.LogError($"Status Code: {ex.Code}");
    Debug.LogError($"Response: {ex.Response}");
}
```
## Preparing Models for Databases API

When working with the Databases API in Unity, models should be prepared for serialization using the System.Text.Json library. By default, System.Text.Json converts property names from PascalCase to camelCase when serializing to JSON. If your Appwrite collection attributes are not in camelCase, this can cause errors due to mismatches between serialized property names and actual attribute names in your collection.

To avoid this, add the `JsonPropertyName` attribute to each property in your model class to match the attribute name in Appwrite:

```csharp
public class TestModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("release_date")]
    public DateTime ReleaseDate { get; set; }
}
```

The `JsonPropertyName` attribute ensures your data object is serialized with the correct attribute names for Appwrite databases. This approach works seamlessly in Unity with the included System.Text.Json DLL.

## Changelog

Please see [CHANGELOG](CHANGELOG.md) for more information about recent changes.

