# UpdateRow

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateRowExample : MonoBehaviour
{
    private Client client;
    private TablesDB tablesDB;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        tablesDB = new TablesDB(client);

        await ExampleUpdateRow();
    }
    
    async UniTask ExampleUpdateRow()
    {
        try
        {
            Row result = await tablesDB.UpdateRow(
                databaseId: "<DATABASE_ID>",
                tableId: "<TABLE_ID>",
                rowId: "<ROW_ID>",
                data: [object], // optional
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
- **tableId** *string* - Table ID. *(required)* 
- **rowId** *string* - Row ID. *(required)* 
- **data** *object* - Row data as JSON object. Include only columns and value pairs to be updated. *(optional)*
- **permissions** *array* - An array of permissions strings. By default, the current permissions are inherited. [Learn more about permissions](https://appwrite.io/docs/permissions). *(optional)*
- **transactionId** *string* - Transaction ID for staging the operation. *(optional)*

## Response

Returns `Row` object.
## More Info

Update a row by its unique ID. Using the patch method you can pass only specific fields that will get updated.
