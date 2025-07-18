# CreateSmtpTest

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateSmtpTestExample : MonoBehaviour
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
        
        await ExampleCreateSmtpTest();
    }
    
    async UniTask ExampleCreateSmtpTest()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var emails = new List<string>(); // Array of emails to send test email to. Maximum of 10 emails are allowed.
            var senderName = "<SENDER_NAME>"; // Name of the email sender
            var senderEmail = "email@example.com"; // Email of the sender
            var host = ""; // SMTP server host name
            
            var result = await client.Projects.CreateSmtpTestAsync(
                projectId,
                emails,
                senderName,
                senderEmail,
                host
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
- **emails** *array* - Array of emails to send test email to. Maximum of 10 emails are allowed. *(required)*
- **senderName** *string* - Name of the email sender *(required)*
- **senderEmail** *string* - Email of the sender *(required)*
- **host** *string* - SMTP server host name *(required)*
- **replyTo** *string* - Reply to email
- **port** *integer* - SMTP server port
- **username** *string* - SMTP server username
- **password** *string* - SMTP server password
- **secure** *string* - Does SMTP server use secure connection

## Response

Returns response object.
## More Info

Send a test email to verify SMTP configuration. 
