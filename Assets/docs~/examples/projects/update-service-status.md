# UpdateServiceStatus

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateServiceStatusExample : MonoBehaviour
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
        
        await ExampleUpdateServiceStatus();
    }
    
    async UniTask ExampleUpdateServiceStatus()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var service = "account"; // Service name.
            var status = false; // Service status.
            
            var result = await client.Projects.UpdateServiceStatusAsync(
                projectId,
                service,
                status
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

- **projectId** *string* - Project unique ID. *(required)*
- **service** *string* - Service name. *(required)*
- **status** *boolean* - Service status. *(required)*

## Response

Returns `Project` object.
## More Info

Update the status of a specific service. Use this endpoint to enable or disable a service in your project. 
