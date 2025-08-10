# UpdateSession

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateSessionExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleUpdateSession();
    }
    
    async UniTask ExampleUpdateSession()
    {
        try
        {
            Session result = await account.UpdateSession(
                sessionId: "<SESSION_ID>"
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
