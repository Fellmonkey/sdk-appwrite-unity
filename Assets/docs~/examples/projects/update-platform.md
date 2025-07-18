# UpdatePlatform

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePlatformExample : MonoBehaviour
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
        
        await ExampleUpdatePlatform();
    }
    
    async UniTask ExampleUpdatePlatform()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var platformId = "<PLATFORM_ID>"; // Platform unique ID.
            var name = "<NAME>"; // Platform name. Max length: 128 chars.
            
            var result = await client.Projects.UpdatePlatformAsync(
                projectId,
                platformId,
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
- **platformId** *string* - Platform unique ID. *(required)*
- **name** *string* - Platform name. Max length: 128 chars. *(required)*
- **key** *string* - Package name for android or bundle ID for iOS. Max length: 256 chars.
- **store** *string* - App store or Google Play store ID. Max length: 256 chars.
- **hostname** *string* - Platform client URL. Max length: 256 chars.

## Response

Returns `Platform` object.
## More Info

Update a platform by its unique ID. Use this endpoint to update the platform&#039;s name, key, platform store ID, or hostname. 
