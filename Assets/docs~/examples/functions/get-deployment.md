# GetDeployment

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetDeploymentExample : MonoBehaviour
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
        
        await ExampleGetDeployment();
    }
    
    async UniTask ExampleGetDeployment()
    {
        try
        {
            // Setup parameters
            var functionId = "<FUNCTION_ID>"; // Function ID.
            var deploymentId = "<DEPLOYMENT_ID>"; // Deployment ID.
            
            var result = await client.Functions.GetDeploymentAsync(
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

## Response

Returns `Deployment` object.
## More Info

Get a function deployment by its unique ID.
