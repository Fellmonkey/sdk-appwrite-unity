# UpdateAuthDuration

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateAuthDurationExample : MonoBehaviour
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
        
        await ExampleUpdateAuthDuration();
    }
    
    async UniTask ExampleUpdateAuthDuration()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var duration = 0; // Project session length in seconds. Max length: 31536000 seconds.
            
            var result = await client.Projects.UpdateAuthDurationAsync(
                projectId,
                duration
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
- **duration** *integer* - Project session length in seconds. Max length: 31536000 seconds. *(required)*

## Response

Returns `Project` object.
## More Info

Update how long sessions created within a project should stay active for.
