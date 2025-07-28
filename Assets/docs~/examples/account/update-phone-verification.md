# UpdatePhoneVerification

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePhoneVerificationExample : MonoBehaviour
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
        
        await ExampleUpdatePhoneVerification();
    }
    
    async UniTask ExampleUpdatePhoneVerification()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var secret = "<SECRET>"; // Valid verification token.
            
            var result = await client.Account.UpdatePhoneVerificationAsync(
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

- **userId** *string* - User ID. *(required)*
- **secret** *string* - Valid verification token. *(required)*

## Response

Returns `Token` object.
## More Info

Use this endpoint to complete the user phone verification process. Use the **userId** and **secret** that were sent to your user&#039;s phone number to verify the user email ownership. If confirmed this route will return a 200 status code.
