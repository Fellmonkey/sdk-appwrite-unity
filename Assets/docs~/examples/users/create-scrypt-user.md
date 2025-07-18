# CreateScryptUser

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateScryptUserExample : MonoBehaviour
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
        
        await ExampleCreateScryptUser();
    }
    
    async UniTask ExampleCreateScryptUser()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var email = "email@example.com"; // User email.
            var password = "password"; // User password hashed using Scrypt.
            var passwordSalt = "<PASSWORD_SALT>"; // Optional salt used to hash password.
            var passwordCpu = 0; // Optional CPU cost used to hash password.
            var passwordMemory = 0; // Optional memory cost used to hash password.
            var passwordParallel = 0; // Optional parallelization cost used to hash password.
            var passwordLength = 0; // Optional hash length used to hash password.
            
            var result = await client.Users.CreateScryptUserAsync(
                userId,
                email,
                password,
                passwordSalt,
                passwordCpu,
                passwordMemory,
                passwordParallel,
                passwordLength
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
- **password** *string* - User password hashed using Scrypt. *(required)*
- **passwordSalt** *string* - Optional salt used to hash password. *(required)*
- **passwordCpu** *integer* - Optional CPU cost used to hash password. *(required)*
- **passwordMemory** *integer* - Optional memory cost used to hash password. *(required)*
- **passwordParallel** *integer* - Optional parallelization cost used to hash password. *(required)*
- **passwordLength** *integer* - Optional hash length used to hash password. *(required)*
- **name** *string* - User name. Max length: 128 chars.

## Response

Returns `User` object.
## More Info

Create a new user. Password provided must be hashed with the [Scrypt](https://github.com/Tarsnap/scrypt) algorithm. Use the [POST /users](https://appwrite.io/docs/server/users#usersCreate) endpoint to create users with a plain text password.
