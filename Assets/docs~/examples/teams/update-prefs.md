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
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteSession("YOUR_SESSION");
              .SetXAppwriteDevKey("YOUR_DEVKEY");
        
        await ExampleUpdatePrefs();
    }
    
    async UniTask ExampleUpdatePrefs()
    {
        try
        {
            // Setup parameters
            var teamId = "<TEAM_ID>"; // Team ID.
            var prefs = [object]; // Prefs key-value JSON object.
            
            var result = await client.Teams.UpdatePrefsAsync(
                teamId,
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

- **teamId** *string* - Team ID. *(required)*
- **prefs** *object* - Prefs key-value JSON object. *(required)*

## Response

Returns `Preferences` object.
## More Info

Update the team&#039;s preferences by its unique ID. The object you pass is stored as is and replaces any previous value. The maximum allowed prefs size is 64kB and throws an error if exceeded.
