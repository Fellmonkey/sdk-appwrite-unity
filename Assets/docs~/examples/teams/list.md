# List

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListExample : MonoBehaviour
{
    private Client client;
    private Teams teams;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        teams = new Teams(client);

        await ExampleList();
    }
    
    async UniTask ExampleList()
    {
        try
        {
            TeamList result = await teams.List(
                queries: new List<string>(), // optional
                search: "<SEARCH>" // optional
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

- **queries** *array* - Array of query strings generated using the Query class provided by the SDK. [Learn more about queries](https://appwrite.io/docs/queries). Maximum of 100 queries are allowed, each 4096 characters long. You may filter on the following attributes: name, total, billingPlan *(optional)*
- **search** *string* - Search term to filter your list results. Max length: 256 chars. *(optional)*

## Response

Returns `TeamList` object.
## More Info

Get a list of all the teams in which the current user is a member. You can use the parameters to filter your results.
