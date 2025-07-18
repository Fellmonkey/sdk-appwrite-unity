# CreateTopic

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateTopicExample : MonoBehaviour
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
        
        await ExampleCreateTopic();
    }
    
    async UniTask ExampleCreateTopic()
    {
        try
        {
            // Setup parameters
            var topicId = "<TOPIC_ID>"; // Topic ID. Choose a custom Topic ID or a new Topic ID.
            var name = "<NAME>"; // Topic Name.
            
            var result = await client.Messaging.CreateTopicAsync(
                topicId,
                name
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

- **topicId** *string* - Topic ID. Choose a custom Topic ID or a new Topic ID. *(required)*
- **name** *string* - Topic Name. *(required)*
- **subscribe** *array* - An array of role strings with subscribe permission. By default all users are granted with any subscribe permission. [learn more about roles](https://appwrite.io/docs/permissions#permission-roles). Maximum of 100 roles are allowed, each 64 characters long.

## Response

Returns `Topic` object.
## More Info

Create a new topic.
