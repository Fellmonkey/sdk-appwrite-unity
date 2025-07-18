# GetFirebaseReport

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetFirebaseReportExample : MonoBehaviour
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
        
        await ExampleGetFirebaseReport();
    }
    
    async UniTask ExampleGetFirebaseReport()
    {
        try
        {
            // Setup parameters
            var resources = new List<string>(); // List of resources to migrate
            var serviceAccount = "<SERVICE_ACCOUNT>"; // JSON of the Firebase service account credentials
            
            var result = await client.Migrations.GetFirebaseReportAsync(
                resources,
                serviceAccount
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
- **serviceAccount** *string* - JSON of the Firebase service account credentials *(required)*

## Response

Returns `MigrationReport` object.
## More Info

Generate a report of the data in a Firebase project before migrating. This endpoint analyzes the source project and returns information about the resources that can be migrated.
