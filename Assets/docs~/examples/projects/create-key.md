# CreateKey

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateKeyExample : MonoBehaviour
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
        
        await ExampleCreateKey();
    }
    
    async UniTask ExampleCreateKey()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var name = "<NAME>"; // Key name. Max length: 128 chars.
            var scopes = new List<string>(); // Key scopes list. Maximum of 100 scopes are allowed.
            
            var result = await client.Projects.CreateKeyAsync(
                projectId,
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
- **name** *string* - Key name. Max length: 128 chars. *(required)*
- **scopes** *array* - Key scopes list. Maximum of 100 scopes are allowed. *(required)*
- **expire** *string* - Expiration time in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Use null for unlimited expiration.

## Response

Returns `Key` object.
## More Info

Create a new API key. It&#039;s recommended to have multiple API keys with strict scopes for separate functions within your project.
