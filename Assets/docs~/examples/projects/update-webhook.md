# UpdateWebhook

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateWebhookExample : MonoBehaviour
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
        
        await ExampleUpdateWebhook();
    }
    
    async UniTask ExampleUpdateWebhook()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var webhookId = "<WEBHOOK_ID>"; // Webhook unique ID.
            var name = "<NAME>"; // Webhook name. Max length: 128 chars.
            var events = new List<string>(); // Events list. Maximum of 100 events are allowed.
            var url = ""; // Webhook URL.
            var security = false; // Certificate verification, false for disabled or true for enabled.
            
            var result = await client.Projects.UpdateWebhookAsync(
                projectId,
                webhookId,
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
- **webhookId** *string* - Webhook unique ID. *(required)*
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

Update a webhook by its unique ID. Use this endpoint to update the URL, events, or status of an existing webhook. 
