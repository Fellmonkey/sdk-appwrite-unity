# GetAppwriteReport

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetAppwriteReportExample : MonoBehaviour
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
        
        await ExampleGetAppwriteReport();
    }
    
    async UniTask ExampleGetAppwriteReport()
    {
        try
        {
            // Setup parameters
            var resources = new List<string>(); // List of resources to migrate
            var endpoint = "https://example.com"; // Source&#039;s Appwrite Endpoint
            var projectID = "<PROJECT_ID>"; // Source&#039;s Project ID
            var key = "<KEY>"; // Source&#039;s API Key
            
            var result = await client.Migrations.GetAppwriteReportAsync(
                resources,
                endpoint,
                projectID,
                key
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

- **resources** *array* - List of resources to migrate *(required)*
- **endpoint** *string* - Source&#039;s Appwrite Endpoint *(required)*
- **projectID** *string* - Source&#039;s Project ID *(required)*
- **key** *string* - Source&#039;s API Key *(required)*

## Response

Returns `MigrationReport` object.
## More Info

Generate a report of the data in an Appwrite project before migrating. This endpoint analyzes the source project and returns information about the resources that can be migrated.
