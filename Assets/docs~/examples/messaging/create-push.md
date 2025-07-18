# CreatePush

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreatePushExample : MonoBehaviour
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
        
        await ExampleCreatePush();
    }
    
    async UniTask ExampleCreatePush()
    {
        try
        {
            // Setup parameters
            var messageId = "<MESSAGE_ID>"; // Message ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            
            var result = await client.Messaging.CreatePushAsync(
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

- **messageId** *string* - Message ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **title** *string* - Title for push notification.
- **body** *string* - Body for push notification.
- **topics** *array* - List of Topic IDs.
- **users** *array* - List of User IDs.
- **targets** *array* - List of Targets IDs.
- **data** *object* - Additional key-value pair data for push notification.
- **action** *string* - Action for push notification.
- **image** *string* - Image for push notification. Must be a compound bucket ID to file ID of a jpeg, png, or bmp image in Appwrite Storage. It should be formatted as &lt;BUCKET_ID&gt;:&lt;FILE_ID&gt;.
- **icon** *string* - Icon for push notification. Available only for Android and Web Platform.
- **sound** *string* - Sound for push notification. Available only for Android and iOS Platform.
- **color** *string* - Color for push notification. Available only for Android Platform.
- **tag** *string* - Tag for push notification. Available only for Android Platform.
- **badge** *integer* - Badge for push notification. Available only for iOS Platform.
- **draft** *boolean* - Is message a draft
- **scheduledAt** *string* - Scheduled delivery time for message in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. DateTime value must be in future.
- **contentAvailable** *boolean* - If set to true, the notification will be delivered in the background. Available only for iOS Platform.
- **critical** *boolean* - If set to true, the notification will be marked as critical. This requires the app to have the critical notification entitlement. Available only for iOS Platform.
- **priority** *string* - Set the notification priority. &quot;normal&quot; will consider device state and may not deliver notifications immediately. &quot;high&quot; will always attempt to immediately deliver the notification.

## Response

Returns `Message` object.
## More Info

Create a new push notification.
