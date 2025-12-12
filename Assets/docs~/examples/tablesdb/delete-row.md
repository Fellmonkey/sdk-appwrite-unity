# DeleteRow

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteRowExample : MonoBehaviour
{
    private Client client;
    private TablesDB tablesDB;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        tablesDB = new TablesDB(client);

        await ExampleDeleteRow();
    }
    
    async UniTask ExampleDeleteRow()
    {
        try
        {
await tablesDB.DeleteRow(
                databaseId: "<DATABASE_ID>",
                tableId: "<TABLE_ID>",
                rowId: "<ROW_ID>",
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
- **tableId** *string* - Table ID. You can create a new table using the Database service [server integration](https://appwrite.io/docs/references/cloud/server-dart/tablesDB#createTable). *(required)* 
- **rowId** *string* - Row ID. *(required)* 
- **transactionId** *string* - Transaction ID for staging the operation. *(optional)*

## Response

Returns response object.
## More Info

Delete a row by its unique ID.
