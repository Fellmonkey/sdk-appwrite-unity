# DeleteDevKey

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteDevKeyExample : MonoBehaviour
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
        
        await ExampleDeleteDevKey();
    }
    
    async UniTask ExampleDeleteDevKey()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var keyId = "<KEY_ID>"; // Key unique ID.
            
            var result = await client.Projects.DeleteDevKeyAsync(
                projectId,
                keyId
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
- **keyId** *string* - Key unique ID. *(required)*

## Response

Returns response object.
## More Info

Delete a project\&#039;s dev key by its unique ID. Once deleted, the key will no longer allow bypassing of rate limits and better logging of errors.
