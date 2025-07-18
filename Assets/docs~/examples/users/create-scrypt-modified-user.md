# CreateScryptModifiedUser

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateScryptModifiedUserExample : MonoBehaviour
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
        
        await ExampleCreateScryptModifiedUser();
    }
    
    async UniTask ExampleCreateScryptModifiedUser()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var email = "email@example.com"; // User email.
            var password = "password"; // User password hashed using Scrypt Modified.
            var passwordSalt = "<PASSWORD_SALT>"; // Salt used to hash password.
            var passwordSaltSeparator = "<PASSWORD_SALT_SEPARATOR>"; // Salt separator used to hash password.
            var passwordSignerKey = "<PASSWORD_SIGNER_KEY>"; // Signer key used to hash password.
            
            var result = await client.Users.CreateScryptModifiedUserAsync(
                userId,
                email,
                password,
                passwordSalt,
                passwordSaltSeparator,
                passwordSignerKey
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

- **userId** *string* - User ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **email** *string* - User email. *(required)*
- **password** *string* - User password hashed using Scrypt Modified. *(required)*
- **passwordSalt** *string* - Salt used to hash password. *(required)*
- **passwordSaltSeparator** *string* - Salt separator used to hash password. *(required)*
- **passwordSignerKey** *string* - Signer key used to hash password. *(required)*
- **name** *string* - User name. Max length: 128 chars.

## Response

Returns `User` object.
## More Info

Create a new user. Password provided must be hashed with the [Scrypt Modified](https://gist.github.com/Meldiron/eecf84a0225eccb5a378d45bb27462cc) algorithm. Use the [POST /users](https://appwrite.io/docs/server/users#usersCreate) endpoint to create users with a plain text password.
