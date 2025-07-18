# ListKeys

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListKeysExample : MonoBehaviour
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
        
        await ExampleListKeys();
    }
    
    async UniTask ExampleListKeys()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            
            var result = await client.Projects.ListKeysAsync(
                projectId
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

## Response

Returns `KeyList` object.
## More Info

Get a list of all API keys from the current project. 
