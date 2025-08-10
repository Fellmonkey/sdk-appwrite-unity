# UpsertDocument

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpsertDocumentExample : MonoBehaviour
{
    private Client client;
    private Databases databases;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        databases = new Databases(client);

        await ExampleUpsertDocument();
    }
    
    async UniTask ExampleUpsertDocument()
    {
        try
        {
            Document result = await databases.UpsertDocument(
                databaseId: "<DATABASE_ID>",
                collectionId: "<COLLECTION_ID>",
                documentId: "<DOCUMENT_ID>",
                data: [object],
                permissions: ["read("any")"] // optional
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
- **permissions** *array* - An array of permissions strings. By default, the current permissions are inherited. [Learn more about permissions](https://appwrite.io/docs/permissions). *(optional)*

## Response

Returns `Document` object.
## More Info

**WARNING: Experimental Feature** - This endpoint is experimental and not yet officially supported. It may be subject to breaking changes or removal in future versions.

Create or update a Document. Before using this route, you should create a new collection resource using either a [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection) API or directly from your database console.
