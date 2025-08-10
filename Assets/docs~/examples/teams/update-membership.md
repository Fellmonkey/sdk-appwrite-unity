# UpdateMembership

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMembershipExample : MonoBehaviour
{
    private Client client;
    private Teams teams;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        teams = new Teams(client);

        await ExampleUpdateMembership();
    }
    
    async UniTask ExampleUpdateMembership()
    {
        try
        {
            Membership result = await teams.UpdateMembership(
                teamId: "<TEAM_ID>",
                membershipId: "<MEMBERSHIP_ID>",
                roles: new List<string>()
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
- **membershipId** *string* - Membership ID. *(required)* 
- **roles** *array* - An array of strings. Use this param to set the user&#039;s roles in the team. A role can be any string. Learn more about [roles and permissions](https://appwrite.io/docs/permissions). Maximum of 100 roles are allowed, each 32 characters long. *(required)* 

## Response

Returns `Membership` object.
## More Info

Modify the roles of a team member. Only team members with the owner role have access to this endpoint. Learn more about [roles and permissions](https://appwrite.io/docs/permissions).

