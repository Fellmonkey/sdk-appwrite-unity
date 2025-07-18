# DeleteWebhook

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteWebhookExample : MonoBehaviour
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
        
        await ExampleDeleteWebhook();
    }
    
    async UniTask ExampleDeleteWebhook()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var webhookId = "<WEBHOOK_ID>"; // Webhook unique ID.
            
            var result = await client.Projects.DeleteWebhookAsync(
                projectId,
                webhookId
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

## Response

Returns response object.
## More Info

Delete a webhook by its unique ID. Once deleted, the webhook will no longer receive project events. 
