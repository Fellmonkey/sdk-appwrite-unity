# GetRepositoryContents

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetRepositoryContentsExample : MonoBehaviour
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
        
        await ExampleGetRepositoryContents();
    }
    
    async UniTask ExampleGetRepositoryContents()
    {
        try
        {
            // Setup parameters
            var installationId = "<INSTALLATION_ID>"; // Installation Id
            var providerRepositoryId = "<PROVIDER_REPOSITORY_ID>"; // Repository Id
            
            var result = await client.Vcs.GetRepositoryContentsAsync(
                installationId,
                providerRepositoryId
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
- **providerRepositoryId** *string* - Repository Id *(required)*
- **providerRootDirectory** *string* - Path to get contents of nested directory
- **providerReference** *string* - Git reference (branch, tag, commit) to get contents from

## Response

Returns `VcsContentList` object.
## More Info

Get a list of files and directories from a GitHub repository connected to your project. This endpoint returns the contents of a specified repository path, including file names, sizes, and whether each item is a file or directory. The GitHub installation must be properly configured and the repository must be accessible through your installation for this endpoint to work.

