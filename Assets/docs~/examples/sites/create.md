# Create

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateExample : MonoBehaviour
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
        
        await ExampleCreate();
    }
    
    async UniTask ExampleCreate()
    {
        try
        {
            // Setup parameters
            var siteId = "<SITE_ID>"; // Site ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var name = "<NAME>"; // Site name. Max length: 128 chars.
            var framework = "analog"; // Sites framework.
            var buildRuntime = "node-14.5"; // Runtime to use during build step.
            
            var result = await client.Sites.CreateAsync(
                siteId,
                name,
                framework,
                buildRuntime
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

- **siteId** *string* - Site ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **name** *string* - Site name. Max length: 128 chars. *(required)*
- **framework** *string* - Sites framework. *(required)*
- **buildRuntime** *string* - Runtime to use during build step. *(required)*
- **enabled** *boolean* - Is site enabled? When set to &#039;disabled&#039;, users cannot access the site but Server SDKs with and API key can still access the site. No data is lost when this is toggled.
- **logging** *boolean* - When disabled, request logs will exclude logs and errors, and site responses will be slightly faster.
- **timeout** *integer* - Maximum request time in seconds.
- **installCommand** *string* - Install Command.
- **buildCommand** *string* - Build Command.
- **outputDirectory** *string* - Output Directory for site.
- **adapter** *string* - Framework adapter defining rendering strategy. Allowed values are: static, ssr
- **installationId** *string* - Appwrite Installation ID for VCS (Version Control System) deployment.
- **fallbackFile** *string* - Fallback file for single page application sites.
- **providerRepositoryId** *string* - Repository ID of the repo linked to the site.
- **providerBranch** *string* - Production branch for the repo linked to the site.
- **providerSilentMode** *boolean* - Is the VCS (Version Control System) connection in silent mode for the repo linked to the site? In silent mode, comments will not be made on commits and pull requests.
- **providerRootDirectory** *string* - Path to site code in the linked repo.
- **specification** *string* - Framework specification for the site and builds.

## Response

Returns `Site` object.
## More Info

Create a new site.
