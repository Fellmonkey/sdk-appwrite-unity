# CreateWebhook

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateWebhookExample : MonoBehaviour
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
        
        await ExampleCreateWebhook();
    }
    
    async UniTask ExampleCreateWebhook()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var name = "<NAME>"; // Webhook name. Max length: 128 chars.
            var events = new List<string>(); // Events list. Maximum of 100 events are allowed.
            var url = ""; // Webhook URL.
            var security = false; // Certificate verification, false for disabled or true for enabled.
            
            var result = await client.Projects.CreateWebhookAsync(
                projectId,
                name,
                events,
                url,
                security
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
- **name** *string* - Webhook name. Max length: 128 chars. *(required)*
- **events** *array* - Events list. Maximum of 100 events are allowed. *(required)*
- **url** *string* - Webhook URL. *(required)*
- **security** *boolean* - Certificate verification, false for disabled or true for enabled. *(required)*
- **enabled** *boolean* - Enable or disable a webhook.
- **httpUser** *string* - Webhook HTTP user. Max length: 256 chars.
- **httpPass** *string* - Webhook HTTP password. Max length: 256 chars.

## Response

Returns `Webhook` object.
## More Info

Create a new webhook. Use this endpoint to configure a URL that will receive events from Appwrite when specific events occur. 
