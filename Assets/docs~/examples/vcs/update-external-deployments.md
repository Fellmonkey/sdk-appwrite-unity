# UpdateExternalDeployments

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateExternalDeploymentsExample : MonoBehaviour
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
        
        await ExampleUpdateExternalDeployments();
    }
    
    async UniTask ExampleUpdateExternalDeployments()
    {
        try
        {
            // Setup parameters
            var installationId = "<INSTALLATION_ID>"; // Installation Id
            var repositoryId = "<REPOSITORY_ID>"; // VCS Repository Id
            var providerPullRequestId = "<PROVIDER_PULL_REQUEST_ID>"; // GitHub Pull Request Id
            
            var result = await client.Vcs.UpdateExternalDeploymentsAsync(
                installationId,
                repositoryId,
                providerPullRequestId
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

- **installationId** *string* - Installation Id *(required)*
- **repositoryId** *string* - VCS Repository Id *(required)*
- **providerPullRequestId** *string* - GitHub Pull Request Id *(required)*

## Response

Returns response object.
## More Info

Authorize and create deployments for a GitHub pull request in your project. This endpoint allows external contributions by creating deployments from pull requests, enabling preview environments for code review. The pull request must be open and not previously authorized. The GitHub installation must be properly configured and have access to both the repository and pull request for this endpoint to work.
