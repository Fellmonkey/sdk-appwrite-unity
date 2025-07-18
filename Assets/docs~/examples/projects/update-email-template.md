# UpdateEmailTemplate

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateEmailTemplateExample : MonoBehaviour
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
        
        await ExampleUpdateEmailTemplate();
    }
    
    async UniTask ExampleUpdateEmailTemplate()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var type = "verification"; // Template type
            var locale = "af"; // Template locale
            var subject = "<SUBJECT>"; // Email Subject
            var message = "<MESSAGE>"; // Template message
            
            var result = await client.Projects.UpdateEmailTemplateAsync(
                projectId,
                type,
                locale,
                subject,
                message
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

- **projectId** *string* - Project unique ID. *(required)*
- **type** *string* - Template type *(required)*
- **locale** *string* - Template locale *(required)*
- **subject** *string* - Email Subject *(required)*
- **message** *string* - Template message *(required)*
- **senderName** *string* - Name of the email sender
- **senderEmail** *string* - Email of the sender
- **replyTo** *string* - Reply to email

## Response

Returns `EmailTemplate` object.
## More Info

Update a custom email template for the specified locale and type. Use this endpoint to modify the content of your email templates.
