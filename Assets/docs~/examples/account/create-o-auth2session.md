# CreateOAuth2Session

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateOAuth2SessionExample : MonoBehaviour
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
        
        await ExampleCreateOAuth2Session();
    }
    
    async UniTask ExampleCreateOAuth2Session()
    {
        try
        {
            // Setup parameters
            var provider = "amazon"; // OAuth2 Provider. Currently, supported providers are: amazon, apple, auth0, authentik, autodesk, bitbucket, bitly, box, dailymotion, discord, disqus, dropbox, etsy, facebook, figma, github, gitlab, google, linkedin, microsoft, notion, oidc, okta, paypal, paypalSandbox, podio, salesforce, slack, spotify, stripe, tradeshift, tradeshiftBox, twitch, wordpress, yahoo, yammer, yandex, zoho, zoom.
            
            var result = await client.Account.CreateOAuth2SessionAsync(
                provider
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

- **provider** *string* - OAuth2 Provider. Currently, supported providers are: amazon, apple, auth0, authentik, autodesk, bitbucket, bitly, box, dailymotion, discord, disqus, dropbox, etsy, facebook, figma, github, gitlab, google, linkedin, microsoft, notion, oidc, okta, paypal, paypalSandbox, podio, salesforce, slack, spotify, stripe, tradeshift, tradeshiftBox, twitch, wordpress, yahoo, yammer, yandex, zoho, zoom. *(required)*
- **success** *string* - URL to redirect back to your app after a successful login attempt.  Only URLs from hostnames in your project&#039;s platform list are allowed. This requirement helps to prevent an [open redirect](https://cheatsheetseries.owasp.org/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.html) attack against your project API.
- **failure** *string* - URL to redirect back to your app after a failed login attempt.  Only URLs from hostnames in your project&#039;s platform list are allowed. This requirement helps to prevent an [open redirect](https://cheatsheetseries.owasp.org/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.html) attack against your project API.
- **scopes** *array* - A list of custom OAuth2 scopes. Check each provider internal docs for a list of supported scopes. Maximum of 100 scopes are allowed, each 4096 characters long.

## Response

Returns boolean indicating success.
## More Info

Allow the user to login to their account using the OAuth2 provider of their choice. Each OAuth2 provider should be enabled from the Appwrite console first. Use the success and failure arguments to provide a redirect URL&#039;s back to your app when login is completed.

If there is already an active session, the new session will be attached to the logged-in account. If there are no active sessions, the server will attempt to look for a user with the same email address as the email received from the OAuth2 provider and attach the new session to the existing user. If no matching user is found - the server will create a new user.

A user is limited to 10 active sessions at a time by default. [Learn more about session limits](https://appwrite.io/docs/authentication-security#limits).

