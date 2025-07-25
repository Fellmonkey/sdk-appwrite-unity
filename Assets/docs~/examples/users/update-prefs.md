# UpdatePrefs

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePrefsExample : MonoBehaviour
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
        
        await ExampleUpdatePrefs();
    }
    
    async UniTask ExampleUpdatePrefs()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var prefs = [object]; // Prefs key-value JSON object.
            
            var result = await client.Users.UpdatePrefsAsync(
                userId,
                prefs
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
- **prefs** *object* - Prefs key-value JSON object. *(required)*

## Response

Returns `Preferences` object.
## More Info

Update the user preferences by its unique ID. The object you pass is stored as is, and replaces any previous value. The maximum allowed prefs size is 64kB and throws error if exceeded.
