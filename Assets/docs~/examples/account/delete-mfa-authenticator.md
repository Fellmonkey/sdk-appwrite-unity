# DeleteMfaAuthenticator

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteMfaAuthenticatorExample : MonoBehaviour
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
        
        await ExampleDeleteMfaAuthenticator();
    }
    
    async UniTask ExampleDeleteMfaAuthenticator()
    {
        try
        {
            // Setup parameters
            var type = "totp"; // Type of authenticator.
            
            var result = await client.Account.DeleteMfaAuthenticatorAsync(
                type
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

- **type** *string* - Type of authenticator. *(required)*

## Response

Returns response object.
## More Info

Delete an authenticator for a user by ID.
