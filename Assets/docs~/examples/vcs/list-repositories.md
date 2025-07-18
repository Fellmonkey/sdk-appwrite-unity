# ListRepositories

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListRepositoriesExample : MonoBehaviour
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
        
        await ExampleListRepositories();
    }
    
    async UniTask ExampleListRepositories()
    {
        try
        {
            // Setup parameters
            var installationId = "<INSTALLATION_ID>"; // Installation Id
            var type = "runtime"; // Detector type. Must be one of the following: runtime, framework
            
            var result = await client.Vcs.ListRepositoriesAsync(
                installationId,
                type
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
- **type** *string* - Detector type. Must be one of the following: runtime, framework *(required)*
- **search** *string* - Search term to filter your list results. Max length: 256 chars.

## Response

Returns `ProviderRepositoryFrameworkList` object.
## More Info

Get a list of GitHub repositories available through your installation. This endpoint returns repositories with their basic information, detected runtime environments, and latest push dates. You can optionally filter repositories using a search term. Each repository&#039;s runtime is automatically detected based on its contents and language statistics. The GitHub installation must be properly configured for this endpoint to work.
