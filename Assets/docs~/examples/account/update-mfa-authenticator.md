# UpdateMfaAuthenticator

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMfaAuthenticatorExample : MonoBehaviour
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
        
        await ExampleUpdateMfaAuthenticator();
    }
    
    async UniTask ExampleUpdateMfaAuthenticator()
    {
        try
        {
            // Setup parameters
            var type = "totp"; // Type of authenticator.
            var otp = "<OTP>"; // Valid verification token.
            
            var result = await client.Account.UpdateMfaAuthenticatorAsync(
                type,
                otp
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

- **type** *string* - Type of authenticator. *(required)*
- **otp** *string* - Valid verification token. *(required)*

## Response

Returns `User` object.
## More Info

Verify an authenticator app after adding it using the [add authenticator](/docs/references/cloud/client-web/account#createMfaAuthenticator) method.
