# CreateDeployment

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateDeploymentExample : MonoBehaviour
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
        
        await ExampleCreateDeployment();
    }
    
    async UniTask ExampleCreateDeployment()
    {
        try
        {
            // Setup parameters
            var siteId = "<SITE_ID>"; // Site ID.
            var code = InputFile.FromPath("./path-to-files/image.jpg"); // Gzip file with your code package. When used with the Appwrite CLI, pass the path to your code directory, and the CLI will automatically package your code. Use a path that is within the current directory.
            var activate = false; // Automatically activate the deployment when it is finished building.
            
            var result = await client.Sites.CreateDeploymentAsync(
                siteId,
                code,
                activate
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
- **code** *file* - Gzip file with your code package. When used with the Appwrite CLI, pass the path to your code directory, and the CLI will automatically package your code. Use a path that is within the current directory. *(required)*
- **activate** *boolean* - Automatically activate the deployment when it is finished building. *(required)*
- **installCommand** *string* - Install Commands.
- **buildCommand** *string* - Build Commands.
- **outputDirectory** *string* - Output Directory.

## Response

Returns `Deployment` object.
## More Info

Create a new site code deployment. Use this endpoint to upload a new version of your site code. To activate your newly uploaded code, you&#039;ll need to update the function&#039;s deployment to use your new deployment ID.
