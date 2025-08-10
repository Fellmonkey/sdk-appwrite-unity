# GetPrefs

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetPrefsExample : MonoBehaviour
{
    private Client client;
    private Teams teams;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        teams = new Teams(client);

        await ExampleGetPrefs();
    }
    
    async UniTask ExampleGetPrefs()
    {
        try
        {
            Preferences result = await teams.GetPrefs(
                teamId: "<TEAM_ID>"
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

## Response

Returns `Preferences` object.
## More Info

Get the team&#039;s shared preferences by its unique ID. If a preference doesn&#039;t need to be shared by all team members, prefer storing them in [user preferences](https://appwrite.io/docs/references/cloud/client-web/account#getPrefs).
