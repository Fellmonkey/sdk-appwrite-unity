# Get

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetExample : MonoBehaviour
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
        
        await ExampleGet();
    }
    
    async UniTask ExampleGet()
    {
        try
        {
            // Setup parameters
            var teamId = "<TEAM_ID>"; // Team ID.
            
            var result = await client.Teams.GetAsync(
                teamId
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

## Response

Returns `Team` object.
## More Info

Get a team by its ID. All team members have read access for this resource.
