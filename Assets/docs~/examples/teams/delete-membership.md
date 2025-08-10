# DeleteMembership

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteMembershipExample : MonoBehaviour
{
    private Client client;
    private Teams teams;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        teams = new Teams(client);

        await ExampleDeleteMembership();
    }
    
    async UniTask ExampleDeleteMembership()
    {
        try
        {
await teams.DeleteMembership(
                teamId: "<TEAM_ID>",
                membershipId: "<MEMBERSHIP_ID>"
            );
            Debug.Log("Success");
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
