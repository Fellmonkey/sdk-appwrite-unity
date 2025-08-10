# UpdateDocument

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateDocumentExample : MonoBehaviour
{
    private Client client;
    private Databases databases;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        databases = new Databases(client);

        await ExampleUpdateDocument();
    }
    
    async UniTask ExampleUpdateDocument()
    {
        try
        {
            Document result = await databases.UpdateDocument(
                databaseId: "<DATABASE_ID>",
                collectionId: "<COLLECTION_ID>",
                documentId: "<DOCUMENT_ID>",
                data: [object], // optional
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
- **data** *object* - Document data as JSON object. Include only attribute and value pairs to be updated. *(optional)*
- **permissions** *array* - An array of permissions strings. By default, the current permissions are inherited. [Learn more about permissions](https://appwrite.io/docs/permissions). *(optional)*

## Response

Returns `Document` object.
## More Info

Update a document by its unique ID. Using the patch method you can pass only specific fields that will get updated.
