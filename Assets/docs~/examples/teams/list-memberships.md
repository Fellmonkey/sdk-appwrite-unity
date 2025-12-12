# ListMemberships

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListMembershipsExample : MonoBehaviour
{
    private Client client;
    private Teams teams;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        teams = new Teams(client);

        await ExampleListMemberships();
    }
    
    async UniTask ExampleListMemberships()
    {
        try
        {
            MembershipList result = await teams.ListMemberships(
                teamId: "<TEAM_ID>",
                queries: new List<string>(), // optional
                search: "<SEARCH>", // optional
                total: false // optional
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
- **queries** *array* - Array of query strings generated using the Query class provided by the SDK. [Learn more about queries](https://appwrite.io/docs/queries). Maximum of 100 queries are allowed, each 4096 characters long. You may filter on the following attributes: userId, teamId, invited, joined, confirm, roles *(optional)*
- **search** *string* - Search term to filter your list results. Max length: 256 chars. *(optional)*
- **total** *boolean* - When set to false, the total count returned will be 0 and will not be calculated. *(optional)*

## Response

Returns `MembershipList` object.
## More Info

Use this endpoint to list a team&#039;s members using the team&#039;s ID. All team members have read access to this endpoint. Hide sensitive attributes from the response by toggling membership privacy in the Console.
