# GetRow

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetRowExample : MonoBehaviour
{
    private Client client;
    private TablesDB tablesDB;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        tablesDB = new TablesDB(client);

        await ExampleGetRow();
    }
    
    async UniTask ExampleGetRow()
    {
        try
        {
            Row result = await tablesDB.GetRow(
                databaseId: "<DATABASE_ID>",
                tableId: "<TABLE_ID>",
                rowId: "<ROW_ID>",
                queries: new List<string>(), // optional
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
- **tableId** *string* - Table ID. You can create a new table using the Database service [server integration](https://appwrite.io/docs/references/cloud/server-dart/tablesDB#createTable). *(required)* 
- **rowId** *string* - Row ID. *(required)* 
- **queries** *array* - Array of query strings generated using the Query class provided by the SDK. [Learn more about queries](https://appwrite.io/docs/queries). Maximum of 100 queries are allowed, each 4096 characters long. *(optional)*
- **transactionId** *string* - Transaction ID to read uncommitted changes within the transaction. *(optional)*

## Response

Returns `Row` object.
## More Info

Get a row by its unique ID. This endpoint response returns a JSON object with the row data.
