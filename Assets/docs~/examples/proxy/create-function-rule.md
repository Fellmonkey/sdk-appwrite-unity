# CreateFunctionRule

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateFunctionRuleExample : MonoBehaviour
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
        
        await ExampleCreateFunctionRule();
    }
    
    async UniTask ExampleCreateFunctionRule()
    {
        try
        {
            // Setup parameters
            var domain = ""; // Domain name.
            var functionId = "<FUNCTION_ID>"; // ID of function to be executed.
            
            var result = await client.Proxy.CreateFunctionRuleAsync(
                domain,
                functionId
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

- **domain** *string* - Domain name. *(required)*
- **functionId** *string* - ID of function to be executed. *(required)*
- **branch** *string* - Name of VCS branch to deploy changes automatically

## Response

Returns `ProxyRule` object.
## More Info

Create a new proxy rule for executing Appwrite Function on custom domain.
