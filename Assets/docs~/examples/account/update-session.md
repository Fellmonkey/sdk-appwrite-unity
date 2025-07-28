# UpdateSession

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateSessionExample : MonoBehaviour
{
    private Client client;
    
    async void Start()
    {
        client = gameObject.AddComponent<Client>();
        client.SetEndpoint("https://cloud.appwrite.io/v1")
              .SetXAppwriteProject("YOUR_PROJECT");
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteSession("YOUR_SESSION");
              .SetXAppwriteDevKey("YOUR_DEVKEY");
        
        await ExampleUpdateSession();
    }
    
    async UniTask ExampleUpdateSession()
    {
        try
        {
            // Setup parameters
            var sessionId = "<SESSION_ID>"; // Session ID. Use the string &#039;current&#039; to update the current device session.
            
            var result = await client.Account.UpdateSessionAsync(
                sessionId
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

- **sessionId** *string* - Session ID. Use the string &#039;current&#039; to update the current device session. *(required)*

## Response

Returns `Session` object.
## More Info

Use this endpoint to extend a session&#039;s length. Extending a session is useful when session expiry is short. If the session was created using an OAuth provider, this endpoint refreshes the access token from the provider.
