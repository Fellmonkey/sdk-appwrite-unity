# GetTarget

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetTargetExample : MonoBehaviour
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
        
        await ExampleGetTarget();
    }
    
    async UniTask ExampleGetTarget()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var targetId = "<TARGET_ID>"; // Target ID.
            
            var result = await client.Users.GetTargetAsync(
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

## Response

Returns `Target` object.
## More Info

Get a user&#039;s push notification target by ID.
