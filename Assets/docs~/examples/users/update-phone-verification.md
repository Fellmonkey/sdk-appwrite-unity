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
              .SetXAppwriteKey("YOUR_KEY");
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteMode("YOUR_MODE");
        
        await ExampleUpdatePhoneVerification();
    }
    
    async UniTask ExampleUpdatePhoneVerification()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var phoneVerification = false; // User phone verification status.
            
            var result = await client.Users.UpdatePhoneVerificationAsync(
                userId,
                phoneVerification
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
- **phoneVerification** *boolean* - User phone verification status. *(required)*

## Response

Returns `User` object.
## More Info

Update the user phone verification status by its unique ID.
