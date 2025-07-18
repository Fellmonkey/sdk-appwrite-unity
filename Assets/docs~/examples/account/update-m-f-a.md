# UpdateMFA

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMFAExample : MonoBehaviour
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
        
        await ExampleUpdateMFA();
    }
    
    async UniTask ExampleUpdateMFA()
    {
        try
        {
            // Setup parameters
            var mfa = false; // Enable or disable MFA.
            
            var result = await client.Account.UpdateMFAAsync(
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

- **mfa** *boolean* - Enable or disable MFA. *(required)*

## Response

Returns `User` object.
## More Info

Enable or disable MFA on an account.
