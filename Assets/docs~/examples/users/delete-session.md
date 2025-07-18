# DeleteSession

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteSessionExample : MonoBehaviour
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
        
        await ExampleDeleteSession();
    }
    
    async UniTask ExampleDeleteSession()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var sessionId = "<SESSION_ID>"; // Session ID.
            
            var result = await client.Users.DeleteSessionAsync(
                userId,
                sessionId
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
- **sessionId** *string* - Session ID. *(required)*

## Response

Returns response object.
## More Info

Delete a user sessions by its unique ID.
