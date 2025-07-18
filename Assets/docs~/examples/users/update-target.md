# UpdateTarget

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateTargetExample : MonoBehaviour
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
        
        await ExampleUpdateTarget();
    }
    
    async UniTask ExampleUpdateTarget()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var targetId = "<TARGET_ID>"; // Target ID.
            
            var result = await client.Users.UpdateTargetAsync(
                userId,
                targetId
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
- **targetId** *string* - Target ID. *(required)*
- **identifier** *string* - The target identifier (token, email, phone etc.)
- **providerId** *string* - Provider ID. Message will be sent to this target from the specified provider ID. If no provider ID is set the first setup provider will be used.
- **name** *string* - Target name. Max length: 128 chars. For example: My Awesome App Galaxy S23.

## Response

Returns `Target` object.
## More Info

Update a messaging target.
