# UpdatePhone

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePhoneExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleUpdatePhone();
    }
    
    async UniTask ExampleUpdatePhone()
    {
        try
        {
            User result = await account.UpdatePhone(
                phone: "+12065550100",
                password: "password"
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
