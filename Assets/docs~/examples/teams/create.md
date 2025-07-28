# Create

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateExample : MonoBehaviour
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
        
        await ExampleCreate();
    }
    
    async UniTask ExampleCreate()
    {
        try
        {
            // Setup parameters
            var teamId = "<TEAM_ID>"; // Team ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var name = "<NAME>"; // Team name. Max length: 128 chars.
            
            var result = await client.Teams.CreateAsync(
                teamId,
                name
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

- **teamId** *string* - Team ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **name** *string* - Team name. Max length: 128 chars. *(required)*
- **roles** *array* - Array of strings. Use this param to set the roles in the team for the user who created it. The default role is **owner**. A role can be any string. Learn more about [roles and permissions](https://appwrite.io/docs/permissions). Maximum of 100 roles are allowed, each 32 characters long.

## Response

Returns `Team` object.
## More Info

Create a new team. The user who creates the team will automatically be assigned as the owner of the team. Only the users with the owner role can invite new members, add new owners and delete or update the team.
