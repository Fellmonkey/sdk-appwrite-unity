# UpdateMembership

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMembershipExample : MonoBehaviour
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
        
        await ExampleUpdateMembership();
    }
    
    async UniTask ExampleUpdateMembership()
    {
        try
        {
            // Setup parameters
            var teamId = "<TEAM_ID>"; // Team ID.
            var membershipId = "<MEMBERSHIP_ID>"; // Membership ID.
            var roles = new List<string>(); // An array of strings. Use this param to set the user&#039;s roles in the team. A role can be any string. Learn more about [roles and permissions](https://appwrite.io/docs/permissions). Maximum of 100 roles are allowed, each 32 characters long.
            
            var result = await client.Teams.UpdateMembershipAsync(
                teamId,
                membershipId,
                roles
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

