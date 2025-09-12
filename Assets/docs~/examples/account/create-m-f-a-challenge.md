# CreateMFAChallenge

## Example

```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateMFAChallengeExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleCreateMFAChallenge();
    }
    
    async UniTask ExampleCreateMFAChallenge()
    {
        try
        {
            MfaChallenge result = await account.CreateMFAChallenge(
                factor: AuthenticationFactor.Email
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

- **factor** *string* - Factor used for verification. Must be one of following: `email`, `phone`, `totp`, `recoveryCode`. *(required)* 

## Response

Returns `MfaChallenge` object.
## More Info

Begin the process of MFA verification after sign-in. Finish the flow with [updateMfaChallenge](/docs/references/cloud/client-web/account#updateMfaChallenge) method.
