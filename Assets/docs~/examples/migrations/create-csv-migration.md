# CreateCsvMigration

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateCsvMigrationExample : MonoBehaviour
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
        
        await ExampleCreateCsvMigration();
    }
    
    async UniTask ExampleCreateCsvMigration()
    {
        try
        {
            // Setup parameters
            var bucketId = "<BUCKET_ID>"; // Storage bucket unique ID. You can create a new storage bucket using the Storage service [server integration](https://appwrite.io/docs/server/storage#createBucket).
            var fileId = "<FILE_ID>"; // File ID.
            var resourceId = "[ID1:ID2]"; // Composite ID in the format {databaseId:collectionId}, identifying a collection within a database.
            
            var result = await client.Migrations.CreateCsvMigrationAsync(
                bucketId,
                fileId,
                resourceId
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

- **bucketId** *string* - Storage bucket unique ID. You can create a new storage bucket using the Storage service [server integration](https://appwrite.io/docs/server/storage#createBucket). *(required)*
- **fileId** *string* - File ID. *(required)*
- **resourceId** *string* - Composite ID in the format {databaseId:collectionId}, identifying a collection within a database. *(required)*

## Response

Returns `Migration` object.
## More Info

Import documents from a CSV file into your Appwrite database. This endpoint allows you to import documents from a CSV file uploaded to Appwrite Storage bucket.
