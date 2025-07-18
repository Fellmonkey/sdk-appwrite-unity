# GetPlatform

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetPlatformExample : MonoBehaviour
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
        
        await ExampleGetPlatform();
    }
    
    async UniTask ExampleGetPlatform()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var platformId = "<PLATFORM_ID>"; // Platform unique ID.
            
            var result = await client.Projects.GetPlatformAsync(
                projectId,
                platformId
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

## Response

Returns `Platform` object.
## More Info

Get a platform by its unique ID. This endpoint returns the platform&#039;s details, including its name, type, and key configurations. 
