# CreateAnonymousSession

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateAnonymousSessionExample : MonoBehaviour
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
        
        await ExampleCreateAnonymousSession();
    }
    
    async UniTask ExampleCreateAnonymousSession()
    {
        try
        {
            var result = await client.Account.CreateAnonymousSessionAsync(
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


## Response

Returns `Session` object.
## More Info

Use this endpoint to allow a new user to register an anonymous account in your project. This route will also create a new session for the user. To allow the new user to convert an anonymous account to a normal account, you need to update its [email and password](https://appwrite.io/docs/references/cloud/client-web/account#updateEmail) or create an [OAuth2 session](https://appwrite.io/docs/references/cloud/client-web/account#CreateOAuth2Session).
