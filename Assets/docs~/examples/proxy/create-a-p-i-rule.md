# CreateAPIRule

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateAPIRuleExample : MonoBehaviour
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
        
        await ExampleCreateAPIRule();
    }
    
    async UniTask ExampleCreateAPIRule()
    {
        try
        {
            // Setup parameters
            var domain = ""; // Domain name.
            
            var result = await client.Proxy.CreateAPIRuleAsync(
                domain
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

## Response

Returns `ProxyRule` object.
## More Info

Create a new proxy rule for serving Appwrite&#039;s API on custom domain.
