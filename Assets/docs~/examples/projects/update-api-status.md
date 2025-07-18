# UpdateApiStatus

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateApiStatusExample : MonoBehaviour
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
        
        await ExampleUpdateApiStatus();
    }
    
    async UniTask ExampleUpdateApiStatus()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var api = "rest"; // API name.
            var status = false; // API status.
            
            var result = await client.Projects.UpdateApiStatusAsync(
                projectId,
                api,
                status
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
- **api** *string* - API name. *(required)*
- **status** *boolean* - API status. *(required)*

## Response

Returns `Project` object.
## More Info

Update the status of a specific API type. Use this endpoint to enable or disable API types such as REST, GraphQL and Realtime.
