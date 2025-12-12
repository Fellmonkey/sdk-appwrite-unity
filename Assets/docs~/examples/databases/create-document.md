# CreateDocument

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateDocumentExample : MonoBehaviour
{
    private Client client;
    private Databases databases;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        databases = new Databases(client);

        await ExampleCreateDocument();
    }
    
    async UniTask ExampleCreateDocument()
    {
        try
        {
            Document result = await databases.CreateDocument(
                databaseId: "<DATABASE_ID>",
                collectionId: "<COLLECTION_ID>",
                documentId: "<DOCUMENT_ID>",
                data: new {
        username = "walter.obrien",
        email = "walter.obrien@example.com",
        fullName = "Walter O'Brien",
        age = 30,
        isAdmin = false
    },
                permissions: new List<string> { Permission.Read(Role.Any()) }, // optional
                transactionId: "<TRANSACTION_ID>" // optional
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
- **collectionId** *string* - Collection ID. You can create a new collection using the Database service [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection). Make sure to define attributes before creating documents. *(required)* 
- **documentId** *string* - Document ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)* 
- **data** *object* - Document data as JSON object. *(required)* 
- **permissions** *array* - An array of permissions strings. By default, only the current user is granted all permissions. [Learn more about permissions](https://appwrite.io/docs/permissions). *(optional)*
- **transactionId** *string* - Transaction ID for staging the operation. *(optional)*

## Response

Returns `Document` object.
## More Info

Create a new Document. Before using this route, you should create a new collection resource using either a [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection) API or directly from your database console.
