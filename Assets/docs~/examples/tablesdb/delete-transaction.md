# DeleteTransaction

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteTransactionExample : MonoBehaviour
{
    private Client client;
    private TablesDB tablesDB;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        tablesDB = new TablesDB(client);

        await ExampleDeleteTransaction();
    }
    
    async UniTask ExampleDeleteTransaction()
    {
        try
        {
await tablesDB.DeleteTransaction(
                transactionId: "<TRANSACTION_ID>"
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

- **transactionId** *string* - Transaction ID. *(required)* 

## Response

Returns response object.
## More Info

Delete a transaction by its unique ID.
