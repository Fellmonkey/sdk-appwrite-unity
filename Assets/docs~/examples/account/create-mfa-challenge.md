# CreateMfaChallenge

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateMfaChallengeExample : MonoBehaviour
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
        
        await ExampleCreateMfaChallenge();
    }
    
    async UniTask ExampleCreateMfaChallenge()
    {
        try
        {
            // Setup parameters
            var factor = "email"; // Factor used for verification. Must be one of following: `email`, `phone`, `totp`, `recoveryCode`.
            
            var result = await client.Account.CreateMfaChallengeAsync(
                factor
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
