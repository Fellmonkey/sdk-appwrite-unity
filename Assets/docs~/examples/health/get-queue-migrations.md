# GetQueueMigrations

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetQueueMigrationsExample : MonoBehaviour
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
        
        await ExampleGetQueueMigrations();
    }
    
    async UniTask ExampleGetQueueMigrations()
    {
        try
        {
            var result = await client.Health.GetQueueMigrationsAsync(
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

- **threshold** *integer* - Queue size threshold. When hit (equal or higher), endpoint returns server error. Default value is 5000.

## Response

Returns `HealthQueue` object.
## More Info

Get the number of migrations that are waiting to be processed in the Appwrite internal queue server.
