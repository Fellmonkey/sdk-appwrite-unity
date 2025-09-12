# UpdateMFAAuthenticator

## Example

```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMFAAuthenticatorExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleUpdateMFAAuthenticator();
    }
    
    async UniTask ExampleUpdateMFAAuthenticator()
    {
        try
        {
            User result = await account.UpdateMFAAuthenticator(
                type: AuthenticatorType.Totp,
                otp: "<OTP>"
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
