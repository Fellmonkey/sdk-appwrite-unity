# GetDeploymentDownload

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetDeploymentDownloadExample : MonoBehaviour
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
        
        await ExampleGetDeploymentDownload();
    }
    
    async UniTask ExampleGetDeploymentDownload()
    {
        try
        {
            // Setup parameters
            var functionId = "<FUNCTION_ID>"; // Function ID.
            var deploymentId = "<DEPLOYMENT_ID>"; // Deployment ID.
            
            var result = await client.Functions.GetDeploymentDownloadAsync(
                functionId,
                deploymentId
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
- **deploymentId** *string* - Deployment ID. *(required)*
- **type** *string* - Deployment file to download. Can be: &quot;source&quot;, &quot;output&quot;.

## Response

Returns byte array of the file.
## More Info

Get a function deployment content by its unique ID. The endpoint response return with a &#039;Content-Disposition: attachment&#039; header that tells the browser to start downloading the file to user downloads directory.
