# GetQueueDatabases

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetQueueDatabasesExample : MonoBehaviour
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
        
        await ExampleGetQueueDatabases();
    }
    
    async UniTask ExampleGetQueueDatabases()
    {
        try
        {
            var result = await client.Health.GetQueueDatabasesAsync(
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

- **name** *string* - Queue name for which to check the queue size
- **threshold** *integer* - Queue size threshold. When hit (equal or higher), endpoint returns server error. Default value is 5000.

## Response

Returns `HealthQueue` object.
## More Info

Get the number of database changes that are waiting to be processed in the Appwrite internal queue server.
