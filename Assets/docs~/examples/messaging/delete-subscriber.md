# DeleteSubscriber

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteSubscriberExample : MonoBehaviour
{
    private Client client;
    private Messaging messaging;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        messaging = new Messaging(client);

        await ExampleDeleteSubscriber();
    }
    
    async UniTask ExampleDeleteSubscriber()
    {
        try
        {
await messaging.DeleteSubscriber(
                topicId: "<TOPIC_ID>",
                subscriberId: "<SUBSCRIBER_ID>"
            );
            Debug.Log("Success");
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
