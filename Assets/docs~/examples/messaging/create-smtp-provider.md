# CreateSmtpProvider

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateSmtpProviderExample : MonoBehaviour
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
        
        await ExampleCreateSmtpProvider();
    }
    
    async UniTask ExampleCreateSmtpProvider()
    {
        try
        {
            // Setup parameters
            var providerId = "<PROVIDER_ID>"; // Provider ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var name = "<NAME>"; // Provider name.
            var host = "<HOST>"; // SMTP hosts. Either a single hostname or multiple semicolon-delimited hostnames. You can also specify a different port for each host such as `smtp1.example.com:25;smtp2.example.com`. You can also specify encryption type, for example: `tls://smtp1.example.com:587;ssl://smtp2.example.com:465&quot;`. Hosts will be tried in order.
            
            var result = await client.Messaging.CreateSmtpProviderAsync(
                providerId,
                name,
                host
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

- **providerId** *string* - Provider ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **name** *string* - Provider name. *(required)*
- **host** *string* - SMTP hosts. Either a single hostname or multiple semicolon-delimited hostnames. You can also specify a different port for each host such as `smtp1.example.com:25;smtp2.example.com`. You can also specify encryption type, for example: `tls://smtp1.example.com:587;ssl://smtp2.example.com:465&quot;`. Hosts will be tried in order. *(required)*
- **port** *integer* - The default SMTP server port.
- **username** *string* - Authentication username.
- **password** *string* - Authentication password.
- **encryption** *string* - Encryption type. Can be omitted, &#039;ssl&#039;, or &#039;tls&#039;
- **autoTLS** *boolean* - Enable SMTP AutoTLS feature.
- **mailer** *string* - The value to use for the X-Mailer header.
- **fromName** *string* - Sender Name.
- **fromEmail** *string* - Sender email address.
- **replyToName** *string* - Name set in the reply to field for the mail. Default value is sender name.
- **replyToEmail** *string* - Email set in the reply to field for the mail. Default value is sender email.
- **enabled** *boolean* - Set as enabled.

## Response

Returns `Provider` object.
## More Info

Create a new SMTP provider.
