# GetDevKey

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetDevKeyExample : MonoBehaviour
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
        
        await ExampleGetDevKey();
    }
    
    async UniTask ExampleGetDevKey()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var keyId = "<KEY_ID>"; // Key unique ID.
            
            var result = await client.Projects.GetDevKeyAsync(
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

Returns `DevKey` object.
## More Info

Get a project\&#039;s dev key by its unique ID. Dev keys are project specific and allow you to bypass rate limits and get better error logging during development.
