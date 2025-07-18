# CreateSendgridProvider

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateSendgridProviderExample : MonoBehaviour
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
        
        await ExampleCreateSendgridProvider();
    }
    
    async UniTask ExampleCreateSendgridProvider()
    {
        try
        {
            // Setup parameters
            var providerId = "<PROVIDER_ID>"; // Provider ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var name = "<NAME>"; // Provider name.
            
            var result = await client.Messaging.CreateSendgridProviderAsync(
                providerId,
                name
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
- **apiKey** *string* - Sendgrid API key.
- **fromName** *string* - Sender Name.
- **fromEmail** *string* - Sender email address.
- **replyToName** *string* - Name set in the reply to field for the mail. Default value is sender name.
- **replyToEmail** *string* - Email set in the reply to field for the mail. Default value is sender email.
- **enabled** *boolean* - Set as enabled.

## Response

Returns `Provider` object.
## More Info

Create a new Sendgrid provider.
