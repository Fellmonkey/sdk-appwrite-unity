# CreateMagicURLToken

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateMagicURLTokenExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleCreateMagicURLToken();
    }
    
    async UniTask ExampleCreateMagicURLToken()
    {
        try
        {
            Token result = await account.CreateMagicURLToken(
                userId: "<USER_ID>",
                email: "email@example.com",
                url: "https://example.com", // optional
                phrase: false // optional
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

- **userId** *string* - Unique Id. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. If the email address has never been used, a new account is created using the provided userId. Otherwise, if the email address is already attached to an account, the user ID is ignored. *(required)* 
- **email** *string* - User email. *(required)* 
- **url** *string* - URL to redirect the user back to your app from the magic URL login. Only URLs from hostnames in your project platform list are allowed. This requirement helps to prevent an [open redirect](https://cheatsheetseries.owasp.org/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.html) attack against your project API. *(optional)*
- **phrase** *boolean* - Toggle for security phrase. If enabled, email will be send with a randomly generated phrase and the phrase will also be included in the response. Confirming phrases match increases the security of your authentication flow. *(optional)*

## Response

Returns `Token` object.
## More Info

Sends the user an email with a secret key for creating a session. If the provided user ID has not been registered, a new user will be created. When the user clicks the link in the email, the user is redirected back to the URL you provided with the secret key and userId values attached to the URL query string. Use the query string parameters to submit a request to the [POST /v1/account/sessions/token](https://appwrite.io/docs/references/cloud/client-web/account#createSession) endpoint to complete the login process. The link sent to the user&#039;s email address is valid for 1 hour.

A user is limited to 10 active sessions at a time by default. [Learn more about session limits](https://appwrite.io/docs/authentication-security#limits).

