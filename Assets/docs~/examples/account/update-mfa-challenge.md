# UpdateMfaChallenge

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMfaChallengeExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleUpdateMfaChallenge();
    }
    
    async UniTask ExampleUpdateMfaChallenge()
    {
        try
        {
            Session result = await account.UpdateMfaChallenge(
                challengeId: "<CHALLENGE_ID>",
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

- **challengeId** *string* - ID of the challenge. *(required)* 
- **otp** *string* - Valid verification token. *(required)* 

## Response

Returns `Session` object.
## More Info

Complete the MFA challenge by providing the one-time password. Finish the process of MFA verification by providing the one-time password. To begin the flow, use [createMfaChallenge](/docs/references/cloud/client-web/account#createMfaChallenge) method.
