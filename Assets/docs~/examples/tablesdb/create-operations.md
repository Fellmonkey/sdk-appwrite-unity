# CreateOperations

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateOperationsExample : MonoBehaviour
{
    private Client client;
    private TablesDB tablesDB;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        tablesDB = new TablesDB(client);

        await ExampleCreateOperations();
    }
    
    async UniTask ExampleCreateOperations()
    {
        try
        {
            Transaction result = await tablesDB.CreateOperations(
                transactionId: "<TRANSACTION_ID>",
                operations: [
	    {
	        "action": "create",
	        "databaseId": "<DATABASE_ID>",
	        "tableId": "<TABLE_ID>",
	        "rowId": "<ROW_ID>",
	        "data": {
	            "name": "Walter O'Brien"
	        }
	    }
	] // optional
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

- **transactionId** *string* - Transaction ID. *(required)* 
- **operations** *array* - Array of staged operations. *(optional)*

## Response

Returns `Transaction` object.
## More Info

Create multiple operations in a single transaction.
