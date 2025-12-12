# CreateRow

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateRowExample : MonoBehaviour
{
    private Client client;
    private TablesDB tablesDB;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        tablesDB = new TablesDB(client);

        await ExampleCreateRow();
    }
    
    async UniTask ExampleCreateRow()
    {
        try
        {
            Row result = await tablesDB.CreateRow(
                databaseId: "<DATABASE_ID>",
                tableId: "<TABLE_ID>",
                rowId: "<ROW_ID>",
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
- **tableId** *string* - Table ID. You can create a new table using the Database service [server integration](https://appwrite.io/docs/references/cloud/server-dart/tablesDB#createTable). Make sure to define columns before creating rows. *(required)* 
- **rowId** *string* - Row ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)* 
- **data** *object* - Row data as JSON object. *(required)* 
- **permissions** *array* - An array of permissions strings. By default, only the current user is granted all permissions. [Learn more about permissions](https://appwrite.io/docs/permissions). *(optional)*
- **transactionId** *string* - Transaction ID for staging the operation. *(optional)*

## Response

Returns `Row` object.
## More Info

Create a new Row. Before using this route, you should create a new table resource using either a [server integration](https://appwrite.io/docs/references/cloud/server-dart/tablesDB#createTable) API or directly from your database console.
