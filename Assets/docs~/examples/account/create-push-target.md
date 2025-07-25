# CreatePushTarget

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreatePushTargetExample : MonoBehaviour
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
        
        await ExampleCreatePushTarget();
    }
    
    async UniTask ExampleCreatePushTarget()
    {
        try
        {
            // Setup parameters
            var targetId = "<TARGET_ID>"; // Target ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var identifier = "<IDENTIFIER>"; // The target identifier (token, email, phone etc.)
            
            var result = await client.Account.CreatePushTargetAsync(
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

- **targetId** *string* - Target ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **identifier** *string* - The target identifier (token, email, phone etc.) *(required)*
- **providerId** *string* - Provider ID. Message will be sent to this target from the specified provider ID. If no provider ID is set the first setup provider will be used.

## Response

Returns `Target` object.
## More Info

Use this endpoint to register a device for push notifications. Provide a target ID (custom or generated using ID.unique()), a device identifier (usually a device token), and optionally specify which provider should send notifications to this target. The target is automatically linked to the current session and includes device information like brand and model.
