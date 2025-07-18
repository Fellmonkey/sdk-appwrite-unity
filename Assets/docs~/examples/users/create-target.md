# CreateTarget

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateTargetExample : MonoBehaviour
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
        
        await ExampleCreateTarget();
    }
    
    async UniTask ExampleCreateTarget()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var targetId = "<TARGET_ID>"; // Target ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var providerType = "email"; // The target provider type. Can be one of the following: `email`, `sms` or `push`.
            var identifier = "<IDENTIFIER>"; // The target identifier (token, email, phone etc.)
            
            var result = await client.Users.CreateTargetAsync(
                userId,
                targetId,
                providerType,
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

- **userId** *string* - User ID. *(required)*
- **targetId** *string* - Target ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **providerType** *string* - The target provider type. Can be one of the following: `email`, `sms` or `push`. *(required)*
- **identifier** *string* - The target identifier (token, email, phone etc.) *(required)*
- **providerId** *string* - Provider ID. Message will be sent to this target from the specified provider ID. If no provider ID is set the first setup provider will be used.
- **name** *string* - Target name. Max length: 128 chars. For example: My Awesome App Galaxy S23.

## Response

Returns `Target` object.
## More Info

Create a messaging target.
