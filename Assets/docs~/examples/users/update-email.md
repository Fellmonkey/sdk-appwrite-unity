# UpdateEmail

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateEmailExample : MonoBehaviour
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
        
        await ExampleUpdateEmail();
    }
    
    async UniTask ExampleUpdateEmail()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var email = "email@example.com"; // User email.
            
            var result = await client.Users.UpdateEmailAsync(
                userId,
                email
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
- **email** *string* - User email. *(required)*

## Response

Returns `User` object.
## More Info

Update the user email by its unique ID.
