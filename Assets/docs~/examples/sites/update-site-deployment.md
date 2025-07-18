# UpdateSiteDeployment

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateSiteDeploymentExample : MonoBehaviour
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
        
        await ExampleUpdateSiteDeployment();
    }
    
    async UniTask ExampleUpdateSiteDeployment()
    {
        try
        {
            // Setup parameters
            var siteId = "<SITE_ID>"; // Site ID.
            var deploymentId = "<DEPLOYMENT_ID>"; // Deployment ID.
            
            var result = await client.Sites.UpdateSiteDeploymentAsync(
                siteId,
                deploymentId
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
- **deploymentId** *string* - Deployment ID. *(required)*

## Response

Returns `Site` object.
## More Info

Update the site active deployment. Use this endpoint to switch the code deployment that should be used when visitor opens your site.
