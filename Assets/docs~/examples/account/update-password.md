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
            var password = ""; // New user password. Must be at least 8 chars.
            
            var result = await client.Account.UpdatePasswordAsync(
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

- **password** *string* - New user password. Must be at least 8 chars. *(required)*
- **oldPassword** *string* - Current user password. Must be at least 8 chars.

## Response

Returns `User` object.
## More Info

Update currently logged in user password. For validation, user is required to pass in the new password, and the old password. For users created with OAuth, Team Invites and Magic URL, oldPassword is optional.
