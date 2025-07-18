# UpdateSessionAlerts

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateSessionAlertsExample : MonoBehaviour
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
        
        await ExampleUpdateSessionAlerts();
    }
    
    async UniTask ExampleUpdateSessionAlerts()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var alerts = false; // Set to true to enable session emails.
            
            var result = await client.Projects.UpdateSessionAlertsAsync(
                projectId,
                alerts
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
- **alerts** *boolean* - Set to true to enable session emails. *(required)*

## Response

Returns `Project` object.
## More Info

Enable or disable session email alerts. When enabled, users will receive email notifications when new sessions are created.
