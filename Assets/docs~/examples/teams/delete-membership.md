# DeleteMembership

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteMembershipExample : MonoBehaviour
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
        
        await ExampleDeleteMembership();
    }
    
    async UniTask ExampleDeleteMembership()
    {
        try
        {
            // Setup parameters
            var teamId = "<TEAM_ID>"; // Team ID.
            var membershipId = "<MEMBERSHIP_ID>"; // Membership ID.
            
            var result = await client.Teams.DeleteMembershipAsync(
                teamId,
                membershipId
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

## Response

Returns response object.
## More Info

This endpoint allows a user to leave a team or for a team owner to delete the membership of any other team member. You can also use this endpoint to delete a user membership even if it is not accepted.
