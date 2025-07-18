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
            var functionId = "<FUNCTION_ID>"; // Function ID.
            var code = InputFile.FromPath("./path-to-files/image.jpg"); // Gzip file with your code package. When used with the Appwrite CLI, pass the path to your code directory, and the CLI will automatically package your code. Use a path that is within the current directory.
            var activate = false; // Automatically activate the deployment when it is finished building.
            
            var result = await client.Functions.CreateDeploymentAsync(
                functionId,
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

- **functionId** *string* - Function ID. *(required)*
- **code** *file* - Gzip file with your code package. When used with the Appwrite CLI, pass the path to your code directory, and the CLI will automatically package your code. Use a path that is within the current directory. *(required)*
- **activate** *boolean* - Automatically activate the deployment when it is finished building. *(required)*
- **entrypoint** *string* - Entrypoint File.
- **commands** *string* - Build Commands.

## Response

Returns `Deployment` object.
## More Info

Create a new function code deployment. Use this endpoint to upload a new version of your code function. To execute your newly uploaded code, you&#039;ll need to update the function&#039;s deployment to use your new deployment UID.

This endpoint accepts a tar.gz file compressed with your code. Make sure to include any dependencies your code has within the compressed file. You can learn more about code packaging in the [Appwrite Cloud Functions tutorial](https://appwrite.io/docs/functions).

Use the &quot;command&quot; param to set the entrypoint used to execute your code.
