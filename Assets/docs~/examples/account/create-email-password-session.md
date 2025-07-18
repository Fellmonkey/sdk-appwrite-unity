# CreateEmailPasswordSession

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateEmailPasswordSessionExample : MonoBehaviour
{
    private Client client;
    
    async void Start()
    {
        client = gameObject.AddComponent<Client>();
        client.SetEndpoint("https://cloud.appwrite.io/v1")
              .SetXAppwriteProject("YOUR_PROJECT");
              .SetXAppwriteKey("YOUR_KEY");
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteMode("YOUR_MODE");
        
        await ExampleCreateEmailPasswordSession();
    }
    
    async UniTask ExampleCreateEmailPasswordSession()
    {
        try
        {
            // Setup parameters
            var email = "email@example.com"; // User email.
            var password = "password"; // User password. Must be at least 8 chars.
            
            var result = await client.Account.CreateEmailPasswordSessionAsync(
                email,
                password
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
