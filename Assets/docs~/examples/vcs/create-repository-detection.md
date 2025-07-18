# CreateRepositoryDetection

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateRepositoryDetectionExample : MonoBehaviour
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
        
        await ExampleCreateRepositoryDetection();
    }
    
    async UniTask ExampleCreateRepositoryDetection()
    {
        try
        {
            // Setup parameters
            var installationId = "<INSTALLATION_ID>"; // Installation Id
            var providerRepositoryId = "<PROVIDER_REPOSITORY_ID>"; // Repository Id
            var type = "runtime"; // Detector type. Must be one of the following: runtime, framework
            
            var result = await client.Vcs.CreateRepositoryDetectionAsync(
                installationId,
                providerRepositoryId,
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
- **providerRepositoryId** *string* - Repository Id *(required)*
- **type** *string* - Detector type. Must be one of the following: runtime, framework *(required)*
- **providerRootDirectory** *string* - Path to Root Directory

## Response

Returns `DetectionFramework` object.
## More Info

Analyze a GitHub repository to automatically detect the programming language and runtime environment. This endpoint scans the repository&#039;s files and language statistics to determine the appropriate runtime settings for your function. The GitHub installation must be properly configured and the repository must be accessible through your installation for this endpoint to work.
