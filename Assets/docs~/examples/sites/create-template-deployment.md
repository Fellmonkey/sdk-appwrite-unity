# CreateTemplateDeployment

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateTemplateDeploymentExample : MonoBehaviour
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
        
        await ExampleCreateTemplateDeployment();
    }
    
    async UniTask ExampleCreateTemplateDeployment()
    {
        try
        {
            // Setup parameters
            var siteId = "<SITE_ID>"; // Site ID.
            var repository = "<REPOSITORY>"; // Repository name of the template.
            var owner = "<OWNER>"; // The name of the owner of the template.
            var rootDirectory = "<ROOT_DIRECTORY>"; // Path to site code in the template repo.
            var version = "<VERSION>"; // Version (tag) for the repo linked to the site template.
            
            var result = await client.Sites.CreateTemplateDeploymentAsync(
                siteId,
                repository,
                owner,
                rootDirectory,
                version
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
- **repository** *string* - Repository name of the template. *(required)*
- **owner** *string* - The name of the owner of the template. *(required)*
- **rootDirectory** *string* - Path to site code in the template repo. *(required)*
- **version** *string* - Version (tag) for the repo linked to the site template. *(required)*
- **activate** *boolean* - Automatically activate the deployment when it is finished building.

## Response

Returns `Deployment` object.
## More Info

Create a deployment based on a template.

Use this endpoint with combination of [listTemplates](https://appwrite.io/docs/server/sites#listTemplates) to find the template details.
