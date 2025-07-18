# UpdateSmtpProvider

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateSmtpProviderExample : MonoBehaviour
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
        
        await ExampleUpdateSmtpProvider();
    }
    
    async UniTask ExampleUpdateSmtpProvider()
    {
        try
        {
            // Setup parameters
            var providerId = "<PROVIDER_ID>"; // Provider ID.
            
            var result = await client.Messaging.UpdateSmtpProviderAsync(
                providerId
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

- **providerId** *string* - Provider ID. *(required)*
- **name** *string* - Provider name.
- **host** *string* - SMTP hosts. Either a single hostname or multiple semicolon-delimited hostnames. You can also specify a different port for each host such as `smtp1.example.com:25;smtp2.example.com`. You can also specify encryption type, for example: `tls://smtp1.example.com:587;ssl://smtp2.example.com:465&quot;`. Hosts will be tried in order.
- **port** *integer* - SMTP port.
- **username** *string* - Authentication username.
- **password** *string* - Authentication password.
- **encryption** *string* - Encryption type. Can be &#039;ssl&#039; or &#039;tls&#039;
- **autoTLS** *boolean* - Enable SMTP AutoTLS feature.
- **mailer** *string* - The value to use for the X-Mailer header.
- **fromName** *string* - Sender Name.
- **fromEmail** *string* - Sender email address.
- **replyToName** *string* - Name set in the Reply To field for the mail. Default value is Sender Name.
- **replyToEmail** *string* - Email set in the Reply To field for the mail. Default value is Sender Email.
- **enabled** *boolean* - Set as enabled.

## Response

Returns `Provider` object.
## More Info

Update a SMTP provider by its unique ID.
