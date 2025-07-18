# UpdateSendgridProvider

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateSendgridProviderExample : MonoBehaviour
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
        
        await ExampleUpdateSendgridProvider();
    }
    
    async UniTask ExampleUpdateSendgridProvider()
    {
        try
        {
            // Setup parameters
            var providerId = "<PROVIDER_ID>"; // Provider ID.
            
            var result = await client.Messaging.UpdateSendgridProviderAsync(
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
- **enabled** *boolean* - Set as enabled.
- **apiKey** *string* - Sendgrid API key.
- **fromName** *string* - Sender Name.
- **fromEmail** *string* - Sender email address.
- **replyToName** *string* - Name set in the Reply To field for the mail. Default value is Sender Name.
- **replyToEmail** *string* - Email set in the Reply To field for the mail. Default value is Sender Email.

## Response

Returns `Provider` object.
## More Info

Update a Sendgrid provider by its unique ID.
