# DecrementRowColumn

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DecrementRowColumnExample : MonoBehaviour
{
    private Client client;
    private TablesDB tablesDB;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        tablesDB = new TablesDB(client);

        await ExampleDecrementRowColumn();
    }
    
    async UniTask ExampleDecrementRowColumn()
    {
        try
        {
            Row result = await tablesDB.DecrementRowColumn(
                databaseId: "<DATABASE_ID>",
                tableId: "<TABLE_ID>",
                rowId: "<ROW_ID>",
                column: "",
                value: 0, // optional
                min: 0 // optional
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
- **column** *string* - Column key. *(required)* 
- **value** *number* - Value to increment the column by. The value must be a number. *(optional)*
- **min** *number* - Minimum value for the column. If the current value is lesser than this value, an exception will be thrown. *(optional)*

## Response

Returns `Row` object.
## More Info

Decrement a specific column of a row by a given value.
