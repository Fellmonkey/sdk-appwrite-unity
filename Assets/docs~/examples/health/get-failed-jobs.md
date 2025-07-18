# GetFailedJobs

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetFailedJobsExample : MonoBehaviour
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
        
        await ExampleGetFailedJobs();
    }
    
    async UniTask ExampleGetFailedJobs()
    {
        try
        {
            // Setup parameters
            var name = "v1-database"; // The name of the queue
            
            var result = await client.Health.GetFailedJobsAsync(
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

- **name** *string* - The name of the queue *(required)*
- **threshold** *integer* - Queue size threshold. When hit (equal or higher), endpoint returns server error. Default value is 5000.

## Response

Returns `HealthQueue` object.
## More Info

Returns the amount of failed jobs in a given queue.

