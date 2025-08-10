# UpdateName

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateNameExample : MonoBehaviour
{
    private Client client;
    private Teams teams;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        teams = new Teams(client);

        await ExampleUpdateName();
    }
    
    async UniTask ExampleUpdateName()
    {
        try
        {
            Team result = await teams.UpdateName(
                teamId: "<TEAM_ID>",
                name: "<NAME>"
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
- **name** *string* - New team name. Max length: 128 chars. *(required)* 

## Response

Returns `Team` object.
## More Info

Update the team&#039;s name by its unique ID.
