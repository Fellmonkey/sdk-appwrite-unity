# DeleteMFAAuthenticator

## Example

```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteMFAAuthenticatorExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleDeleteMFAAuthenticator();
    }
    
    async UniTask ExampleDeleteMFAAuthenticator()
    {
        try
        {
await account.DeleteMFAAuthenticator(
                type: AuthenticatorType.Totp
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

- **type** *string* - Type of authenticator. *(required)* 

## Response

Returns response object.
## More Info

Delete an authenticator for a user by ID.
