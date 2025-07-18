# CreateAppwriteMigration

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateAppwriteMigrationExample : MonoBehaviour
{
    private Client client;
    
    async void Start()
    {
        client = gameObject.AddComponent<Client>();
        client.SetEndpoint("https://cloud.appwrite.io/v1")
              .SetXAppwriteProject("YOUR_PROJECT");
              .SetXAppwriteKey("YOUR_KEY");
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteMode("YOUR_MODE");
        
        await ExampleCreateAppwriteMigration();
    }
    
    async UniTask ExampleCreateAppwriteMigration()
    {
        try
        {
            // Setup parameters
            var resources = new List<string>(); // List of resources to migrate
            var endpoint = "https://example.com"; // Source Appwrite endpoint
            var projectId = "<PROJECT_ID>"; // Source Project ID
            var apiKey = "<API_KEY>"; // Source API Key
            
            var result = await client.Migrations.CreateAppwriteMigrationAsync(
                resources,
                endpoint,
                projectId,
                apiKey
            );
            
            Debug.Log("Success: " + result);
        }
        catch (AppwriteException ex)
        {
            Debug.LogError($"Error: {ex.Message} (Code: {ex.Code})");
        }
    }
}
```

## Parameters

- **resources** *array* - List of resources to migrate *(required)*
- **endpoint** *string* - Source Appwrite endpoint *(required)*
- **projectId** *string* - Source Project ID *(required)*
- **apiKey** *string* - Source API Key *(required)*

## Response

Returns `Migration` object.
## More Info

Migrate data from another Appwrite project to your current project. This endpoint allows you to migrate resources like databases, collections, documents, users, and files from an existing Appwrite project. 
