# GetTransaction

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetTransactionExample : MonoBehaviour
{
    private Client client;
    private TablesDB tablesDB;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        tablesDB = new TablesDB(client);

        await ExampleGetTransaction();
    }
    
    async UniTask ExampleGetTransaction()
    {
        try
        {
            Transaction result = await tablesDB.GetTransaction(
                transactionId: "<TRANSACTION_ID>"
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

## Response

Returns `Transaction` object.
## More Info

Get a transaction by its unique ID.
