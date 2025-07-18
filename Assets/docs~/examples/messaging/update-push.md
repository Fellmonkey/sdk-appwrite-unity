# UpdatePush

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePushExample : MonoBehaviour
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
        
        await ExampleUpdatePush();
    }
    
    async UniTask ExampleUpdatePush()
    {
        try
        {
            // Setup parameters
            var messageId = "<MESSAGE_ID>"; // Message ID.
            
            var result = await client.Messaging.UpdatePushAsync(
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
- **title** *string* - Title for push notification.
- **body** *string* - Body for push notification.
- **data** *object* - Additional Data for push notification.
- **action** *string* - Action for push notification.
- **image** *string* - Image for push notification. Must be a compound bucket ID to file ID of a jpeg, png, or bmp image in Appwrite Storage. It should be formatted as &lt;BUCKET_ID&gt;:&lt;FILE_ID&gt;.
- **icon** *string* - Icon for push notification. Available only for Android and Web platforms.
- **sound** *string* - Sound for push notification. Available only for Android and iOS platforms.
- **color** *string* - Color for push notification. Available only for Android platforms.
- **tag** *string* - Tag for push notification. Available only for Android platforms.
- **badge** *integer* - Badge for push notification. Available only for iOS platforms.
- **draft** *boolean* - Is message a draft
- **scheduledAt** *string* - Scheduled delivery time for message in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. DateTime value must be in future.
- **contentAvailable** *boolean* - If set to true, the notification will be delivered in the background. Available only for iOS Platform.
- **critical** *boolean* - If set to true, the notification will be marked as critical. This requires the app to have the critical notification entitlement. Available only for iOS Platform.
- **priority** *string* - Set the notification priority. &quot;normal&quot; will consider device battery state and may send notifications later. &quot;high&quot; will always attempt to immediately deliver the notification.

## Response

Returns `Message` object.
## More Info

Update a push notification by its unique ID. This endpoint only works on messages that are in draft status. Messages that are already processing, sent, or failed cannot be updated.

