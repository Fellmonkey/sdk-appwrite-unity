# DeleteSessions

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteSessionsExample : MonoBehaviour
{
    private Client client;
    
    async void Start()
    {
        client = gameObject.AddComponent<Client>();
        client.SetEndpoint("https://cloud.appwrite.io/v1")
              .SetXAppwriteProject("YOUR_PROJECT");
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteSession("YOUR_SESSION");
              .SetXAppwriteDevKey("YOUR_DEVKEY");
        
        await ExampleDeleteSessions();
    }
    
    async UniTask ExampleDeleteSessions()
    {
        try
        {
            var result = await client.Account.DeleteSessionsAsync(
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


## Response

Returns response object.
## More Info

Delete all sessions from the user account and remove any sessions cookies from the end client.
