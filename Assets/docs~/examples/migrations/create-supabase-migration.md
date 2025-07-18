# CreateSupabaseMigration

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateSupabaseMigrationExample : MonoBehaviour
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
        
        await ExampleCreateSupabaseMigration();
    }
    
    async UniTask ExampleCreateSupabaseMigration()
    {
        try
        {
            // Setup parameters
            var resources = new List<string>(); // List of resources to migrate
            var endpoint = "https://example.com"; // Source&#039;s Supabase Endpoint
            var apiKey = "<API_KEY>"; // Source&#039;s API Key
            var databaseHost = "<DATABASE_HOST>"; // Source&#039;s Database Host
            var username = "<USERNAME>"; // Source&#039;s Database Username
            var password = "<PASSWORD>"; // Source&#039;s Database Password
            
            var result = await client.Migrations.CreateSupabaseMigrationAsync(
                resources,
                endpoint,
                apiKey,
                databaseHost,
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

- **resources** *array* - List of resources to migrate *(required)*
- **endpoint** *string* - Source&#039;s Supabase Endpoint *(required)*
- **apiKey** *string* - Source&#039;s API Key *(required)*
- **databaseHost** *string* - Source&#039;s Database Host *(required)*
- **username** *string* - Source&#039;s Database Username *(required)*
- **password** *string* - Source&#039;s Database Password *(required)*
- **port** *integer* - Source&#039;s Database Port

## Response

Returns `Migration` object.
## More Info

Migrate data from a Supabase project to your Appwrite project. This endpoint allows you to migrate resources like authentication, databases, and other supported services from a Supabase project. 
