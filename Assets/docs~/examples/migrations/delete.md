# Delete

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteExample : MonoBehaviour
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
        
        await ExampleDelete();
    }
    
    async UniTask ExampleDelete()
    {
        try
        {
            // Setup parameters
            var migrationId = "<MIGRATION_ID>"; // Migration ID.
            
            var result = await client.Migrations.DeleteAsync(
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

- **migrationId** *string* - Migration ID. *(required)*

## Response

Returns response object.
## More Info

Delete a migration by its unique ID. This endpoint allows you to remove a migration from your project&#039;s migration history. 
