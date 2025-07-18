# UpdateMfa

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMfaExample : MonoBehaviour
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
        
        await ExampleUpdateMfa();
    }
    
    async UniTask ExampleUpdateMfa()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var mfa = false; // Enable or disable MFA.
            
            var result = await client.Users.UpdateMfaAsync(
                userId,
                mfa
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
- **mfa** *boolean* - Enable or disable MFA. *(required)*

## Response

Returns `User` object.
## More Info

Enable or disable MFA on a user account.
