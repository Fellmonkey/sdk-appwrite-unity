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
            var userId = "<USER_ID>"; // User ID.
            
            var result = await client.Users.CreateJWTAsync(
                userId
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

- **userId** *string* - User ID. *(required)*
- **sessionId** *string* - Session ID. Use the string &#039;recent&#039; to use the most recent session. Defaults to the most recent session.
- **duration** *integer* - Time in seconds before JWT expires. Default duration is 900 seconds, and maximum is 3600 seconds.

## Response

Returns `Jwt` object.
## More Info

Use this endpoint to create a JSON Web Token for user by its unique ID. You can use the resulting JWT to authenticate on behalf of the user. The JWT secret will become invalid if the session it uses gets deleted.
