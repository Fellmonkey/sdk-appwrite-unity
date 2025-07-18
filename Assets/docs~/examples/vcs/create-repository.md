# CreateRepository

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateRepositoryExample : MonoBehaviour
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
        
        await ExampleCreateRepository();
    }
    
    async UniTask ExampleCreateRepository()
    {
        try
        {
            // Setup parameters
            var installationId = "<INSTALLATION_ID>"; // Installation Id
            var name = "<NAME>"; // Repository name (slug)
            var private = false; // Mark repository public or private
            
            var result = await client.Vcs.CreateRepositoryAsync(
                installationId,
                name,
                private
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
- **name** *string* - Repository name (slug) *(required)*
- **private** *boolean* - Mark repository public or private *(required)*

## Response

Returns `ProviderRepository` object.
## More Info

Create a new GitHub repository through your installation. This endpoint allows you to create either a public or private repository by specifying a name and visibility setting. The repository will be created under your GitHub user account or organization, depending on your installation type. The GitHub installation must be properly configured and have the necessary permissions for repository creation.
