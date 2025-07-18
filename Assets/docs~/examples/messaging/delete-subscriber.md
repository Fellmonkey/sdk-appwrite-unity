# DeleteSubscriber

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteSubscriberExample : MonoBehaviour
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
        
        await ExampleDeleteSubscriber();
    }
    
    async UniTask ExampleDeleteSubscriber()
    {
        try
        {
            // Setup parameters
            var topicId = "<TOPIC_ID>"; // Topic ID. The topic ID subscribed to.
            var subscriberId = "<SUBSCRIBER_ID>"; // Subscriber ID.
            
            var result = await client.Messaging.DeleteSubscriberAsync(
                topicId,
                subscriberId
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

- **topicId** *string* - Topic ID. The topic ID subscribed to. *(required)*
- **subscriberId** *string* - Subscriber ID. *(required)*

## Response

Returns response object.
## More Info

Delete a subscriber by its unique ID.
