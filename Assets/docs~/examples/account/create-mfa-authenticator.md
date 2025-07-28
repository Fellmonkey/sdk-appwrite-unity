# CreateMfaAuthenticator

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateMfaAuthenticatorExample : MonoBehaviour
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
        
        await ExampleCreateMfaAuthenticator();
    }
    
    async UniTask ExampleCreateMfaAuthenticator()
    {
        try
        {
            // Setup parameters
            var type = "totp"; // Type of authenticator. Must be `totp`
            
            var result = await client.Account.CreateMfaAuthenticatorAsync(
                type
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

- **type** *string* - Type of authenticator. Must be `totp` *(required)*

## Response

Returns `MfaType` object.
## More Info

Add an authenticator app to be used as an MFA factor. Verify the authenticator using the [verify authenticator](/docs/references/cloud/client-web/account#updateMfaAuthenticator) method.
