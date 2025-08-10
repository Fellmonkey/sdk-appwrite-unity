# UpdatePrefs

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePrefsExample : MonoBehaviour
{
    private Client client;
    private Teams teams;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        teams = new Teams(client);

        await ExampleUpdatePrefs();
    }
    
    async UniTask ExampleUpdatePrefs()
    {
        try
        {
            Preferences result = await teams.UpdatePrefs(
                teamId: "<TEAM_ID>",
                prefs: [object]
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
