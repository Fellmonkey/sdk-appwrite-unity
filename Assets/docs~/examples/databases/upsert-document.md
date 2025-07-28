# UpsertDocument

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpsertDocumentExample : MonoBehaviour
{
    private Client client;
    
    async void Start()
    {
        client = gameObject.AddComponent<Client>();
        client.SetEndpoint("https://cloud.appwrite.io/v1")
              .SetXAppwriteProject("YOUR_PROJECT");
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteSession("YOUR_SESSION");
              .SetXAppwriteDevKey("YOUR_DEVKEY");
        
        await ExampleUpsertDocument();
    }
    
    async UniTask ExampleUpsertDocument()
    {
        try
        {
            // Setup parameters
            var databaseId = "<DATABASE_ID>"; // Database ID.
            var collectionId = "<COLLECTION_ID>"; // Collection ID.
            var documentId = "<DOCUMENT_ID>"; // Document ID.
            var data = [object]; // Document data as JSON object. Include all required attributes of the document to be created or updated.
            
            var result = await client.Databases.UpsertDocumentAsync(
                databaseId,
                collectionId,
                documentId,
                data
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
- **documentId** *string* - Document ID. *(required)*
- **data** *object* - Document data as JSON object. Include all required attributes of the document to be created or updated. *(required)*
- **permissions** *array* - An array of permissions strings. By default, the current permissions are inherited. [Learn more about permissions](https://appwrite.io/docs/permissions).

## Response

Returns `Document` object.
## More Info

**WARNING: Experimental Feature** - This endpoint is experimental and not yet officially supported. It may be subject to breaking changes or removal in future versions.

Create or update a Document. Before using this route, you should create a new collection resource using either a [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection) API or directly from your database console.
