# CreateRedirectRule

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateRedirectRuleExample : MonoBehaviour
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
        
        await ExampleCreateRedirectRule();
    }
    
    async UniTask ExampleCreateRedirectRule()
    {
        try
        {
            // Setup parameters
            var domain = ""; // Domain name.
            var url = "https://example.com"; // Target URL of redirection
            var statusCode = "301"; // Status code of redirection
            var resourceId = "<RESOURCE_ID>"; // ID of parent resource.
            var resourceType = "site"; // Type of parent resource.
            
            var result = await client.Proxy.CreateRedirectRuleAsync(
                domain,
                url,
                statusCode,
                resourceId,
                resourceType
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
- **url** *string* - Target URL of redirection *(required)*
- **statusCode** *string* - Status code of redirection *(required)*
- **resourceId** *string* - ID of parent resource. *(required)*
- **resourceType** *string* - Type of parent resource. *(required)*

## Response

Returns `ProxyRule` object.
## More Info

Create a new proxy rule for to redirect from custom domain to another domain.
