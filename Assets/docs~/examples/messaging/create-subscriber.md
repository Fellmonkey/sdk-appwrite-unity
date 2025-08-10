# CreateSubscriber

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateSubscriberExample : MonoBehaviour
{
    private Client client;
    private Messaging messaging;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        messaging = new Messaging(client);

        await ExampleCreateSubscriber();
    }
    
    async UniTask ExampleCreateSubscriber()
    {
        try
        {
            Subscriber result = await messaging.CreateSubscriber(
                topicId: "<TOPIC_ID>",
                subscriberId: "<SUBSCRIBER_ID>",
                targetId: "<TARGET_ID>"
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
