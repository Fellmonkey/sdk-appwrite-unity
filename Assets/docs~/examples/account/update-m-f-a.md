# UpdateMFA

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMFAExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleUpdateMFA();
    }
    
    async UniTask ExampleUpdateMFA()
    {
        try
        {
            User result = await account.UpdateMFA(
                mfa: false
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

- **mfa** *boolean* - Enable or disable MFA. *(required)* 

## Response

Returns `User` object.
## More Info

Enable or disable MFA on an account.
