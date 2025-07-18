# UpdatePassword

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePasswordExample : MonoBehaviour
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
        
        await ExampleUpdatePassword();
    }
    
    async UniTask ExampleUpdatePassword()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var password = ""; // New user password. Must be at least 8 chars.
            
            var result = await client.Users.UpdatePasswordAsync(
                userId,
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

- **userId** *string* - User ID. *(required)*
- **password** *string* - New user password. Must be at least 8 chars. *(required)*

## Response

Returns `User` object.
## More Info

Update the user password by its unique ID.
