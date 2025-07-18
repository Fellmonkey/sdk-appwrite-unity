# UpdateSmtp

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateSmtpExample : MonoBehaviour
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
        
        await ExampleUpdateSmtp();
    }
    
    async UniTask ExampleUpdateSmtp()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var enabled = false; // Enable custom SMTP service
            
            var result = await client.Projects.UpdateSmtpAsync(
                projectId,
                enabled
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
- **enabled** *boolean* - Enable custom SMTP service *(required)*
- **senderName** *string* - Name of the email sender
- **senderEmail** *string* - Email of the sender
- **replyTo** *string* - Reply to email
- **host** *string* - SMTP server host name
- **port** *integer* - SMTP server port
- **username** *string* - SMTP server username
- **password** *string* - SMTP server password
- **secure** *string* - Does SMTP server use secure connection

## Response

Returns `Project` object.
## More Info

Update the SMTP configuration for your project. Use this endpoint to configure your project&#039;s SMTP provider with your custom settings for sending transactional emails. 
