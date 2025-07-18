# GetMessage

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetMessageExample : MonoBehaviour
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
        
        await ExampleGetMessage();
    }
    
    async UniTask ExampleGetMessage()
    {
        try
        {
            // Setup parameters
            var messageId = "<MESSAGE_ID>"; // Message ID.
            
            var result = await client.Messaging.GetMessageAsync(
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

Returns `Message` object.
## More Info

Get a message by its unique ID.

