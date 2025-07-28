# GetMembership

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetMembershipExample : MonoBehaviour
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
        
        await ExampleGetMembership();
    }
    
    async UniTask ExampleGetMembership()
    {
        try
        {
            // Setup parameters
            var teamId = "<TEAM_ID>"; // Team ID.
            var membershipId = "<MEMBERSHIP_ID>"; // Membership ID.
            
            var result = await client.Teams.GetMembershipAsync(
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

Returns `Membership` object.
## More Info

Get a team member by the membership unique id. All team members have read access for this resource. Hide sensitive attributes from the response by toggling membership privacy in the Console.
