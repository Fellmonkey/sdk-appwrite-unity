# CreateEmailPasswordSession

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateEmailPasswordSessionExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleCreateEmailPasswordSession();
    }
    
    async UniTask ExampleCreateEmailPasswordSession()
    {
        try
        {
            Session result = await account.CreateEmailPasswordSession(
                email: "email@example.com",
                password: "password"
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

- **email** *string* - User email. *(required)* 
- **password** *string* - User password. Must be at least 8 chars. *(required)* 

## Response

Returns `Session` object.
## More Info

Allow the user to login into their account by providing a valid email and password combination. This route will create a new session for the user.

A user is limited to 10 active sessions at a time by default. [Learn more about session limits](https://appwrite.io/docs/authentication-security#limits).
