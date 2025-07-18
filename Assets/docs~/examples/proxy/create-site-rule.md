# CreateSiteRule

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateSiteRuleExample : MonoBehaviour
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
        
        await ExampleCreateSiteRule();
    }
    
    async UniTask ExampleCreateSiteRule()
    {
        try
        {
            // Setup parameters
            var domain = ""; // Domain name.
            var siteId = "<SITE_ID>"; // ID of site to be executed.
            
            var result = await client.Proxy.CreateSiteRuleAsync(
                domain,
                siteId
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
- **siteId** *string* - ID of site to be executed. *(required)*
- **branch** *string* - Name of VCS branch to deploy changes automatically

## Response

Returns `ProxyRule` object.
## More Info

Create a new proxy rule for serving Appwrite Site on custom domain.
