# CreateSHAUser

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateSHAUserExample : MonoBehaviour
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
        
        await ExampleCreateSHAUser();
    }
    
    async UniTask ExampleCreateSHAUser()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var email = "email@example.com"; // User email.
            var password = "password"; // User password hashed using SHA.
            
            var result = await client.Users.CreateSHAUserAsync(
                userId,
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

- **userId** *string* - User ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **email** *string* - User email. *(required)*
- **password** *string* - User password hashed using SHA. *(required)*
- **passwordVersion** *string* - Optional SHA version used to hash password. Allowed values are: &#039;sha1&#039;, &#039;sha224&#039;, &#039;sha256&#039;, &#039;sha384&#039;, &#039;sha512/224&#039;, &#039;sha512/256&#039;, &#039;sha512&#039;, &#039;sha3-224&#039;, &#039;sha3-256&#039;, &#039;sha3-384&#039;, &#039;sha3-512&#039;
- **name** *string* - User name. Max length: 128 chars.

## Response

Returns `User` object.
## More Info

Create a new user. Password provided must be hashed with the [SHA](https://en.wikipedia.org/wiki/Secure_Hash_Algorithm) algorithm. Use the [POST /users](https://appwrite.io/docs/server/users#usersCreate) endpoint to create users with a plain text password.
