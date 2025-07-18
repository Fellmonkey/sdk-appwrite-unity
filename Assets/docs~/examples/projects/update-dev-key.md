# UpdateDevKey

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateDevKeyExample : MonoBehaviour
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
        
        await ExampleUpdateDevKey();
    }
    
    async UniTask ExampleUpdateDevKey()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var keyId = "<KEY_ID>"; // Key unique ID.
            var name = "<NAME>"; // Key name. Max length: 128 chars.
            var expire = ""; // Expiration time in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format.
            
            var result = await client.Projects.UpdateDevKeyAsync(
                projectId,
                keyId,
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
- **keyId** *string* - Key unique ID. *(required)*
- **name** *string* - Key name. Max length: 128 chars. *(required)*
- **expire** *string* - Expiration time in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. *(required)*

## Response

Returns `DevKey` object.
## More Info

Update a project\&#039;s dev key by its unique ID. Use this endpoint to update a project\&#039;s dev key name or expiration time.&#039;
