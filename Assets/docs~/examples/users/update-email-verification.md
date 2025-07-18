# UpdateEmailVerification

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateEmailVerificationExample : MonoBehaviour
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
        
        await ExampleUpdateEmailVerification();
    }
    
    async UniTask ExampleUpdateEmailVerification()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var emailVerification = false; // User email verification status.
            
            var result = await client.Users.UpdateEmailVerificationAsync(
                userId,
                emailVerification
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
- **emailVerification** *boolean* - User email verification status. *(required)*

## Response

Returns `User` object.
## More Info

Update the user email verification status by its unique ID.
