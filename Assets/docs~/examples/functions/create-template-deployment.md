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
            var functionId = "<FUNCTION_ID>"; // Function ID.
            var repository = "<REPOSITORY>"; // Repository name of the template.
            var owner = "<OWNER>"; // The name of the owner of the template.
            var rootDirectory = "<ROOT_DIRECTORY>"; // Path to function code in the template repo.
            var version = "<VERSION>"; // Version (tag) for the repo linked to the function template.
            
            var result = await client.Functions.CreateTemplateDeploymentAsync(
                functionId,
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

- **functionId** *string* - Function ID. *(required)*
- **repository** *string* - Repository name of the template. *(required)*
- **owner** *string* - The name of the owner of the template. *(required)*
- **rootDirectory** *string* - Path to function code in the template repo. *(required)*
- **version** *string* - Version (tag) for the repo linked to the function template. *(required)*
- **activate** *boolean* - Automatically activate the deployment when it is finished building.

## Response

Returns `Deployment` object.
## More Info

Create a deployment based on a template.

Use this endpoint with combination of [listTemplates](https://appwrite.io/docs/server/functions#listTemplates) to find the template details.
