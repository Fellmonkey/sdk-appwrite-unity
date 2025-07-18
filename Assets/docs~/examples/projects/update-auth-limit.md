# UpdateAuthLimit

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateAuthLimitExample : MonoBehaviour
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
        
        await ExampleUpdateAuthLimit();
    }
    
    async UniTask ExampleUpdateAuthLimit()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var limit = 0; // Set the max number of users allowed in this project. Use 0 for unlimited.
            
            var result = await client.Projects.UpdateAuthLimitAsync(
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
- **limit** *integer* - Set the max number of users allowed in this project. Use 0 for unlimited. *(required)*

## Response

Returns `Project` object.
## More Info

Update the maximum number of users allowed in this project. Set to 0 for unlimited users. 
