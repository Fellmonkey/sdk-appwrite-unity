# UpdateMembershipStatus

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMembershipStatusExample : MonoBehaviour
{
    private Client client;
    private Teams teams;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        teams = new Teams(client);

        await ExampleUpdateMembershipStatus();
    }
    
    async UniTask ExampleUpdateMembershipStatus()
    {
        try
        {
            Membership result = await teams.UpdateMembershipStatus(
                teamId: "<TEAM_ID>",
                membershipId: "<MEMBERSHIP_ID>",
                userId: "<USER_ID>",
                secret: "<SECRET>"
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
- **userId** *string* - User ID. *(required)* 
- **secret** *string* - Secret key. *(required)* 

## Response

Returns `Membership` object.
## More Info

Use this endpoint to allow a user to accept an invitation to join a team after being redirected back to your app from the invitation email received by the user.

If the request is successful, a session for the user is automatically created.

