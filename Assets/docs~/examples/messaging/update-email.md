# UpdateEmail

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateEmailExample : MonoBehaviour
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
        
        await ExampleUpdateEmail();
    }
    
    async UniTask ExampleUpdateEmail()
    {
        try
        {
            // Setup parameters
            var messageId = "<MESSAGE_ID>"; // Message ID.
            
            var result = await client.Messaging.UpdateEmailAsync(
                messageId
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

- **messageId** *string* - Message ID. *(required)*
- **topics** *array* - List of Topic IDs.
- **users** *array* - List of User IDs.
- **targets** *array* - List of Targets IDs.
- **subject** *string* - Email Subject.
- **content** *string* - Email Content.
- **draft** *boolean* - Is message a draft
- **html** *boolean* - Is content of type HTML
- **cc** *array* - Array of target IDs to be added as CC.
- **bcc** *array* - Array of target IDs to be added as BCC.
- **scheduledAt** *string* - Scheduled delivery time for message in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. DateTime value must be in future.
- **attachments** *array* - Array of compound ID strings of bucket IDs and file IDs to be attached to the email. They should be formatted as &lt;BUCKET_ID&gt;:&lt;FILE_ID&gt;.

## Response

Returns `Message` object.
## More Info

Update an email message by its unique ID. This endpoint only works on messages that are in draft status. Messages that are already processing, sent, or failed cannot be updated.

