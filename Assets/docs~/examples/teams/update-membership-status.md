# UpdateMembershipStatus

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMembershipStatusExample : MonoBehaviour
{
    private Client client;
    
    async void Start()
    {
        client = gameObject.AddComponent<Client>();
        client.SetEndpoint("https://cloud.appwrite.io/v1")
              .SetXAppwriteProject("YOUR_PROJECT");
              .SetXAppwriteKey("YOUR_KEY");
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteMode("YOUR_MODE");
        
        await ExampleUpdateMembershipStatus();
    }
    
    async UniTask ExampleUpdateMembershipStatus()
    {
        try
        {
            // Setup parameters
            var teamId = "<TEAM_ID>"; // Team ID.
            var membershipId = "<MEMBERSHIP_ID>"; // Membership ID.
            var userId = "<USER_ID>"; // User ID.
            var secret = "<SECRET>"; // Secret key.
            
            var result = await client.Teams.UpdateMembershipStatusAsync(
                teamId,
                membershipId,
                userId,
                secret
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

