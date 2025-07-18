# UpsertDocuments

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpsertDocumentsExample : MonoBehaviour
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
        
        await ExampleUpsertDocuments();
    }
    
    async UniTask ExampleUpsertDocuments()
    {
        try
        {
            // Setup parameters
            var databaseId = "<DATABASE_ID>"; // Database ID.
            var collectionId = "<COLLECTION_ID>"; // Collection ID.
            var documents = new List<object>(); // Array of document data as JSON objects. May contain partial documents.
            
            var result = await client.Databases.UpsertDocumentsAsync(
                databaseId,
                collectionId,
                documents
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

- **databaseId** *string* - Database ID. *(required)*
- **collectionId** *string* - Collection ID. *(required)*
- **documents** *array* - Array of document data as JSON objects. May contain partial documents. *(required)*

## Response

Returns `DocumentList` object.
## More Info

**WARNING: Experimental Feature** - This endpoint is experimental and not yet officially supported. It may be subject to breaking changes or removal in future versions.

Create or update Documents. Before using this route, you should create a new collection resource using either a [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection) API or directly from your database console.
