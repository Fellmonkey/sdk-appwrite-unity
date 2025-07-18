# CreateJWT

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateJWTExample : MonoBehaviour
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
        
        await ExampleCreateJWT();
    }
    
    async UniTask ExampleCreateJWT()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var scopes = new List<string>(); // List of scopes allowed for JWT key. Maximum of 100 scopes are allowed.
            
            var result = await client.Projects.CreateJWTAsync(
                projectId,
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
- **scopes** *array* - List of scopes allowed for JWT key. Maximum of 100 scopes are allowed. *(required)*
- **duration** *integer* - Time in seconds before JWT expires. Default duration is 900 seconds, and maximum is 3600 seconds.

## Response

Returns `Jwt` object.
## More Info

Create a new JWT token. This token can be used to authenticate users with custom scopes and expiration time. 
