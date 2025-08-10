# ListMfaFactors

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListMfaFactorsExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleListMfaFactors();
    }
    
    async UniTask ExampleListMfaFactors()
    {
        try
        {
            MfaFactors result = await account.ListMfaFactors();

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


## Response

Returns `MfaFactors` object.
## More Info

List the factors available on the account to be used as a MFA challange.
