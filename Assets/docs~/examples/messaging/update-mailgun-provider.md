# UpdateMailgunProvider

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMailgunProviderExample : MonoBehaviour
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
        
        await ExampleUpdateMailgunProvider();
    }
    
    async UniTask ExampleUpdateMailgunProvider()
    {
        try
        {
            // Setup parameters
            var providerId = "<PROVIDER_ID>"; // Provider ID.
            
            var result = await client.Messaging.UpdateMailgunProviderAsync(
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
- **apiKey** *string* - Mailgun API Key.
- **domain** *string* - Mailgun Domain.
- **isEuRegion** *boolean* - Set as EU region.
- **enabled** *boolean* - Set as enabled.
- **fromName** *string* - Sender Name.
- **fromEmail** *string* - Sender email address.
- **replyToName** *string* - Name set in the reply to field for the mail. Default value is sender name.
- **replyToEmail** *string* - Email set in the reply to field for the mail. Default value is sender email.

## Response

Returns `Provider` object.
## More Info

Update a Mailgun provider by its unique ID.
