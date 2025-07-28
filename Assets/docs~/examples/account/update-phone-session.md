# UpdatePhoneSession

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePhoneSessionExample : MonoBehaviour
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
        
        await ExampleUpdatePhoneSession();
    }
    
    async UniTask ExampleUpdatePhoneSession()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var secret = "<SECRET>"; // Valid verification token.
            
            var result = await client.Account.UpdatePhoneSessionAsync(
                userId,
                secret
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

- **userId** *string* - User ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **secret** *string* - Valid verification token. *(required)*

## Response

Returns `Session` object.
## More Info

Use this endpoint to create a session from token. Provide the **userId** and **secret** parameters from the successful response of authentication flows initiated by token creation. For example, magic URL and phone login.
