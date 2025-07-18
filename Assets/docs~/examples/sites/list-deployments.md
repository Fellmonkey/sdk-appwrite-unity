# ListDeployments

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListDeploymentsExample : MonoBehaviour
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
        
        await ExampleListDeployments();
    }
    
    async UniTask ExampleListDeployments()
    {
        try
        {
            // Setup parameters
            var siteId = "<SITE_ID>"; // Site ID.
            
            var result = await client.Sites.ListDeploymentsAsync(
                siteId
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

- **siteId** *string* - Site ID. *(required)*
- **queries** *array* - Array of query strings generated using the Query class provided by the SDK. [Learn more about queries](https://appwrite.io/docs/queries). Maximum of 100 queries are allowed, each 4096 characters long. You may filter on the following attributes: buildSize, sourceSize, totalSize, buildDuration, status, activate, type
- **search** *string* - Search term to filter your list results. Max length: 256 chars.

## Response

Returns `DeploymentList` object.
## More Info

Get a list of all the site&#039;s code deployments. You can use the query params to filter your results.
