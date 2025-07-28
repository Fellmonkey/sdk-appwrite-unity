# UpdateMfaChallenge

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMfaChallengeExample : MonoBehaviour
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
        
        await ExampleUpdateMfaChallenge();
    }
    
    async UniTask ExampleUpdateMfaChallenge()
    {
        try
        {
            // Setup parameters
            var challengeId = "<CHALLENGE_ID>"; // ID of the challenge.
            var otp = "<OTP>"; // Valid verification token.
            
            var result = await client.Account.UpdateMfaChallengeAsync(
                challengeId,
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

- **challengeId** *string* - ID of the challenge. *(required)*
- **otp** *string* - Valid verification token. *(required)*

## Response

Returns `Session` object.
## More Info

Complete the MFA challenge by providing the one-time password. Finish the process of MFA verification by providing the one-time password. To begin the flow, use [createMfaChallenge](/docs/references/cloud/client-web/account#createMfaChallenge) method.
