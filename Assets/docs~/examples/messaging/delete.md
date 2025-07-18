# Delete

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteExample : MonoBehaviour
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
        
        await ExampleDelete();
    }
    
    async UniTask ExampleDelete()
    {
        try
        {
            // Setup parameters
            var messageId = "<MESSAGE_ID>"; // Message ID.
            
            var result = await client.Messaging.DeleteAsync(
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

## Response

Returns response object.
## More Info

Delete a message. If the message is not a draft or scheduled, but has been sent, this will not recall the message.
