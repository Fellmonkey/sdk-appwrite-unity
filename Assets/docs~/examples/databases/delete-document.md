# DeleteDocument

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteDocumentExample : MonoBehaviour
{
    private Client client;
    private Databases databases;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        databases = new Databases(client);

        await ExampleDeleteDocument();
    }
    
    async UniTask ExampleDeleteDocument()
    {
        try
        {
await databases.DeleteDocument(
                databaseId: "<DATABASE_ID>",
                collectionId: "<COLLECTION_ID>",
                documentId: "<DOCUMENT_ID>",
                transactionId: "<TRANSACTION_ID>" // optional
            );
            Debug.Log("Success");
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
- **collectionId** *string* - Collection ID. You can create a new collection using the Database service [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection). *(required)* 
- **documentId** *string* - Document ID. *(required)* 
- **transactionId** *string* - Transaction ID for staging the operation. *(optional)*

## Response

Returns response object.
## More Info

Delete a document by its unique ID.
