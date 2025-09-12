# UpsertRow

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpsertRowExample : MonoBehaviour
{
    private Client client;
    private TablesDB tablesDB;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        tablesDB = new TablesDB(client);

        await ExampleUpsertRow();
    }
    
    async UniTask ExampleUpsertRow()
    {
        try
        {
            Row result = await tablesDB.UpsertRow(
                databaseId: "<DATABASE_ID>",
                tableId: "<TABLE_ID>",
                rowId: "<ROW_ID>",
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
- **tableId** *string* - Table ID. *(required)* 
- **rowId** *string* - Row ID. *(required)* 
- **data** *object* - Row data as JSON object. Include all required columns of the row to be created or updated. *(optional)*
- **permissions** *array* - An array of permissions strings. By default, the current permissions are inherited. [Learn more about permissions](https://appwrite.io/docs/permissions). *(optional)*

## Response

Returns `Row` object.
## More Info

Create or update a Row. Before using this route, you should create a new table resource using either a [server integration](https://appwrite.io/docs/server/tablesdb#tablesDBCreateTable) API or directly from your database console.
