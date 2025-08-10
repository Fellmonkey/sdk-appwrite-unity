# UpdatePassword

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePasswordExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleUpdatePassword();
    }
    
    async UniTask ExampleUpdatePassword()
    {
        try
        {
            User result = await account.UpdatePassword(
                password: "",
                oldPassword: "password" // optional
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

- **password** *string* - New user password. Must be at least 8 chars. *(required)* 
- **oldPassword** *string* - Current user password. Must be at least 8 chars. *(optional)*

## Response

Returns `User` object.
## More Info

Update currently logged in user password. For validation, user is required to pass in the new password, and the old password. For users created with OAuth, Team Invites and Magic URL, oldPassword is optional.
