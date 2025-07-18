# CreateVcsDeployment

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateVcsDeploymentExample : MonoBehaviour
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
        
        await ExampleCreateVcsDeployment();
    }
    
    async UniTask ExampleCreateVcsDeployment()
    {
        try
        {
            // Setup parameters
            var siteId = "<SITE_ID>"; // Site ID.
            var type = "branch"; // Type of reference passed. Allowed values are: branch, commit
            var reference = "<REFERENCE>"; // VCS reference to create deployment from. Depending on type this can be: branch name, commit hash
            
            var result = await client.Sites.CreateVcsDeploymentAsync(
                siteId,
                type,
                reference
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
- **type** *string* - Type of reference passed. Allowed values are: branch, commit *(required)*
- **reference** *string* - VCS reference to create deployment from. Depending on type this can be: branch name, commit hash *(required)*
- **activate** *boolean* - Automatically activate the deployment when it is finished building.

## Response

Returns `Deployment` object.
## More Info

Create a deployment when a site is connected to VCS.

This endpoint lets you create deployment from a branch, commit, or a tag.
