# UpdateAuthSessionsLimit

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateAuthSessionsLimitExample : MonoBehaviour
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
        
        await ExampleUpdateAuthSessionsLimit();
    }
    
    async UniTask ExampleUpdateAuthSessionsLimit()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var limit = 1; // Set the max number of users allowed in this project. Value allowed is between 1-100. Default is 10
            
            var result = await client.Projects.UpdateAuthSessionsLimitAsync(
                projectId,
                limit
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
- **limit** *integer* - Set the max number of users allowed in this project. Value allowed is between 1-100. Default is 10 *(required)*

## Response

Returns `Project` object.
## More Info

Update the maximum number of sessions allowed per user within the project, if the limit is hit the oldest session will be deleted to make room for new sessions.
