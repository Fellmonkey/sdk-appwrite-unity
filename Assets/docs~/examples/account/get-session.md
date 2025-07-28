# GetSession

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetSessionExample : MonoBehaviour
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
        
        await ExampleGetSession();
    }
    
    async UniTask ExampleGetSession()
    {
        try
        {
            // Setup parameters
            var sessionId = "<SESSION_ID>"; // Session ID. Use the string &#039;current&#039; to get the current device session.
            
            var result = await client.Account.GetSessionAsync(
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

- **sessionId** *string* - Session ID. Use the string &#039;current&#039; to get the current device session. *(required)*

## Response

Returns `Session` object.
## More Info

Use this endpoint to get a logged in user&#039;s session using a Session ID. Inputting &#039;current&#039; will return the current session being used.
