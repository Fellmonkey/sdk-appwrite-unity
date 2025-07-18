# ListSubscriberLogs

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListSubscriberLogsExample : MonoBehaviour
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
        
        await ExampleListSubscriberLogs();
    }
    
    async UniTask ExampleListSubscriberLogs()
    {
        try
        {
            // Setup parameters
            var subscriberId = "<SUBSCRIBER_ID>"; // Subscriber ID.
            
            var result = await client.Messaging.ListSubscriberLogsAsync(
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

- **subscriberId** *string* - Subscriber ID. *(required)*
- **queries** *array* - Array of query strings generated using the Query class provided by the SDK. [Learn more about queries](https://appwrite.io/docs/queries). Only supported methods are limit and offset

## Response

Returns `LogList` object.
## More Info

Get the subscriber activity logs listed by its unique ID.
