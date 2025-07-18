# GetNHostReport

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetNHostReportExample : MonoBehaviour
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
        
        await ExampleGetNHostReport();
    }
    
    async UniTask ExampleGetNHostReport()
    {
        try
        {
            // Setup parameters
            var resources = new List<string>(); // List of resources to migrate.
            var subdomain = "<SUBDOMAIN>"; // Source&#039;s Subdomain.
            var region = "<REGION>"; // Source&#039;s Region.
            var adminSecret = "<ADMIN_SECRET>"; // Source&#039;s Admin Secret.
            var database = "<DATABASE>"; // Source&#039;s Database Name.
            var username = "<USERNAME>"; // Source&#039;s Database Username.
            var password = "<PASSWORD>"; // Source&#039;s Database Password.
            
            var result = await client.Migrations.GetNHostReportAsync(
                resources,
                subdomain,
                region,
                adminSecret,
                database,
                username,
                password
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

- **resources** *array* - List of resources to migrate. *(required)*
- **subdomain** *string* - Source&#039;s Subdomain. *(required)*
- **region** *string* - Source&#039;s Region. *(required)*
- **adminSecret** *string* - Source&#039;s Admin Secret. *(required)*
- **database** *string* - Source&#039;s Database Name. *(required)*
- **username** *string* - Source&#039;s Database Username. *(required)*
- **password** *string* - Source&#039;s Database Password. *(required)*
- **port** *integer* - Source&#039;s Database Port.

## Response

Returns `MigrationReport` object.
## More Info

Generate a detailed report of the data in an NHost project before migrating. This endpoint analyzes the source project and returns information about the resources that can be migrated. 
