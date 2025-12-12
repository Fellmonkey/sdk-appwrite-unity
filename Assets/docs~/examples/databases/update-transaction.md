# UpdateTransaction

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateTransactionExample : MonoBehaviour
{
    private Client client;
    private Databases databases;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        databases = new Databases(client);

        await ExampleUpdateTransaction();
    }
    
    async UniTask ExampleUpdateTransaction()
    {
        try
        {
            Transaction result = await databases.UpdateTransaction(
                transactionId: "<TRANSACTION_ID>",
                commit: false, // optional
                rollback: false // optional
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
- **commit** *boolean* - Commit transaction? *(optional)*
- **rollback** *boolean* - Rollback transaction? *(optional)*

## Response

Returns `Transaction` object.
## More Info

Update a transaction, to either commit or roll back its operations.
