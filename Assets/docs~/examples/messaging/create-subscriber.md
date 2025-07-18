# CreateSubscriber

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateSubscriberExample : MonoBehaviour
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
        
        await ExampleCreateSubscriber();
    }
    
    async UniTask ExampleCreateSubscriber()
    {
        try
        {
            // Setup parameters
            var topicId = "<TOPIC_ID>"; // Topic ID. The topic ID to subscribe to.
            var subscriberId = "<SUBSCRIBER_ID>"; // Subscriber ID. Choose a custom Subscriber ID or a new Subscriber ID.
            var targetId = "<TARGET_ID>"; // Target ID. The target ID to link to the specified Topic ID.
            
            var result = await client.Messaging.CreateSubscriberAsync(
                topicId,
                subscriberId,
                targetId
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

- **topicId** *string* - Topic ID. The topic ID to subscribe to. *(required)*
- **subscriberId** *string* - Subscriber ID. Choose a custom Subscriber ID or a new Subscriber ID. *(required)*
- **targetId** *string* - Target ID. The target ID to link to the specified Topic ID. *(required)*

## Response

Returns `Subscriber` object.
## More Info

Create a new subscriber.
