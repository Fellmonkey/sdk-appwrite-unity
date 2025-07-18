# UpdateKey

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateKeyExample : MonoBehaviour
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
        
        await ExampleUpdateKey();
    }
    
    async UniTask ExampleUpdateKey()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var keyId = "<KEY_ID>"; // Key unique ID.
            var name = "<NAME>"; // Key name. Max length: 128 chars.
            var scopes = new List<string>(); // Key scopes list. Maximum of 100 events are allowed.
            
            var result = await client.Projects.UpdateKeyAsync(
                projectId,
                keyId,
                name,
                scopes
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
- **name** *string* - Key name. Max length: 128 chars. *(required)*
- **scopes** *array* - Key scopes list. Maximum of 100 events are allowed. *(required)*
- **expire** *string* - Expiration time in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Use null for unlimited expiration.

## Response

Returns `Key` object.
## More Info

Update a key by its unique ID. Use this endpoint to update the name, scopes, or expiration time of an API key. 
