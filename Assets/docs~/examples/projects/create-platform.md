# CreatePlatform

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreatePlatformExample : MonoBehaviour
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
        
        await ExampleCreatePlatform();
    }
    
    async UniTask ExampleCreatePlatform()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var type = "web"; // Platform type.
            var name = "<NAME>"; // Platform name. Max length: 128 chars.
            
            var result = await client.Projects.CreatePlatformAsync(
                projectId,
                type,
                name
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

- **projectId** *string* - Project unique ID. *(required)*
- **type** *string* - Platform type. *(required)*
- **name** *string* - Platform name. Max length: 128 chars. *(required)*
- **key** *string* - Package name for Android or bundle ID for iOS or macOS. Max length: 256 chars.
- **store** *string* - App store or Google Play store ID. Max length: 256 chars.
- **hostname** *string* - Platform client hostname. Max length: 256 chars.

## Response

Returns `Platform` object.
## More Info

Create a new platform for your project. Use this endpoint to register a new platform where your users will run your application which will interact with the Appwrite API.
