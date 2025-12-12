# CreateTransaction

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateTransactionExample : MonoBehaviour
{
    private Client client;
    private TablesDB tablesDB;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        tablesDB = new TablesDB(client);

        await ExampleCreateTransaction();
    }
    
    async UniTask ExampleCreateTransaction()
    {
        try
        {
            Transaction result = await tablesDB.CreateTransaction(
                ttl: 60 // optional
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

- **ttl** *integer* - Seconds before the transaction expires. *(optional)*

## Response

Returns `Transaction` object.
## More Info

Create a new transaction.
