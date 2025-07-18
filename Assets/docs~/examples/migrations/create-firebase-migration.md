# CreateFirebaseMigration

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateFirebaseMigrationExample : MonoBehaviour
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
        
        await ExampleCreateFirebaseMigration();
    }
    
    async UniTask ExampleCreateFirebaseMigration()
    {
        try
        {
            // Setup parameters
            var resources = new List<string>(); // List of resources to migrate
            var serviceAccount = "<SERVICE_ACCOUNT>"; // JSON of the Firebase service account credentials
            
            var result = await client.Migrations.CreateFirebaseMigrationAsync(
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

Returns `Migration` object.
## More Info

Migrate data from a Firebase project to your Appwrite project. This endpoint allows you to migrate resources like authentication and other supported services from a Firebase project. 
