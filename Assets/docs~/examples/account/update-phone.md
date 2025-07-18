# UpdatePhone

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePhoneExample : MonoBehaviour
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
        
        await ExampleUpdatePhone();
    }
    
    async UniTask ExampleUpdatePhone()
    {
        try
        {
            // Setup parameters
            var phone = "+12065550100"; // Phone number. Format this number with a leading &#039;+&#039; and a country code, e.g., +16175551212.
            var password = "password"; // User password. Must be at least 8 chars.
            
            var result = await client.Account.UpdatePhoneAsync(
                phone,
                password
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

- **phone** *string* - Phone number. Format this number with a leading &#039;+&#039; and a country code, e.g., +16175551212. *(required)*
- **password** *string* - User password. Must be at least 8 chars. *(required)*

## Response

Returns `User` object.
## More Info

Update the currently logged in user&#039;s phone number. After updating the phone number, the phone verification status will be reset. A confirmation SMS is not sent automatically, however you can use the [POST /account/verification/phone](https://appwrite.io/docs/references/cloud/client-web/account#createPhoneVerification) endpoint to send a confirmation SMS.
