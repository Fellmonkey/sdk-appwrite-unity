# CreateSms

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateSmsExample : MonoBehaviour
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
        
        await ExampleCreateSms();
    }
    
    async UniTask ExampleCreateSms()
    {
        try
        {
            // Setup parameters
            var messageId = "<MESSAGE_ID>"; // Message ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var content = "<CONTENT>"; // SMS Content.
            
            var result = await client.Messaging.CreateSmsAsync(
                messageId,
                content
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

- **messageId** *string* - Message ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **content** *string* - SMS Content. *(required)*
- **topics** *array* - List of Topic IDs.
- **users** *array* - List of User IDs.
- **targets** *array* - List of Targets IDs.
- **draft** *boolean* - Is message a draft
- **scheduledAt** *string* - Scheduled delivery time for message in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. DateTime value must be in future.

## Response

Returns `Message` object.
## More Info

Create a new SMS message.
