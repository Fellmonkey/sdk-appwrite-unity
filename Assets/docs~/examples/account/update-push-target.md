# UpdatePushTarget

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePushTargetExample : MonoBehaviour
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
        
        await ExampleUpdatePushTarget();
    }
    
    async UniTask ExampleUpdatePushTarget()
    {
        try
        {
            // Setup parameters
            var targetId = "<TARGET_ID>"; // Target ID.
            var identifier = "<IDENTIFIER>"; // The target identifier (token, email, phone etc.)
            
            var result = await client.Account.UpdatePushTargetAsync(
                targetId,
                identifier
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

- **targetId** *string* - Target ID. *(required)*
- **identifier** *string* - The target identifier (token, email, phone etc.) *(required)*

## Response

Returns `Target` object.
## More Info

Update the currently logged in user&#039;s push notification target. You can modify the target&#039;s identifier (device token) and provider ID (token, email, phone etc.). The target must exist and belong to the current user. If you change the provider ID, notifications will be sent through the new messaging provider instead.
