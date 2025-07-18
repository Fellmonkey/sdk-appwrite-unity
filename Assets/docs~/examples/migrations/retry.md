# Retry

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class RetryExample : MonoBehaviour
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
        
        await ExampleRetry();
    }
    
    async UniTask ExampleRetry()
    {
        try
        {
            // Setup parameters
            var migrationId = "<MIGRATION_ID>"; // Migration unique ID.
            
            var result = await client.Migrations.RetryAsync(
                migrationId
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

- **migrationId** *string* - Migration unique ID. *(required)*

## Response

Returns `Migration` object.
## More Info

Retry a failed migration. This endpoint allows you to retry a migration that has previously failed.
