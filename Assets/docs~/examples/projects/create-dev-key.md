# CreateDevKey

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateDevKeyExample : MonoBehaviour
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
        
        await ExampleCreateDevKey();
    }
    
    async UniTask ExampleCreateDevKey()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var name = "<NAME>"; // Key name. Max length: 128 chars.
            var expire = ""; // Expiration time in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            
            var result = await client.Projects.CreateDevKeyAsync(
                projectId,
                name,
                expire
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
- **name** *string* - Key name. Max length: 128 chars. *(required)*
- **expire** *string* - Expiration time in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. *(required)*

## Response

Returns `DevKey` object.
## More Info

Create a new project dev key. Dev keys are project specific and allow you to bypass rate limits and get better error logging during development. Strictly meant for development purposes only.
