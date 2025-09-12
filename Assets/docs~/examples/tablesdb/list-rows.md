# ListRows

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListRowsExample : MonoBehaviour
{
    private Client client;
    private TablesDB tablesDB;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        tablesDB = new TablesDB(client);

        await ExampleListRows();
    }
    
    async UniTask ExampleListRows()
    {
        try
        {
            RowList result = await tablesDB.ListRows(
                databaseId: "<DATABASE_ID>",
                tableId: "<TABLE_ID>",
                queries: new List<string>() // optional
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
- **tableId** *string* - Table ID. You can create a new table using the TableDB service [server integration](https://appwrite.io/docs/server/tablesdbdb#tablesdbCreate). *(required)* 
- **queries** *array* - Array of query strings generated using the Query class provided by the SDK. [Learn more about queries](https://appwrite.io/docs/queries). Maximum of 100 queries are allowed, each 4096 characters long. *(optional)*

## Response

Returns `RowList` object.
## More Info

Get a list of all the user&#039;s rows in a given table. You can use the query params to filter your results.
