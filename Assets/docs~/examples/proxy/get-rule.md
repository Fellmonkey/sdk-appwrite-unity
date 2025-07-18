# GetRule

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetRuleExample : MonoBehaviour
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
        
        await ExampleGetRule();
    }
    
    async UniTask ExampleGetRule()
    {
        try
        {
            // Setup parameters
            var ruleId = "<RULE_ID>"; // Rule ID.
            
            var result = await client.Proxy.GetRuleAsync(
                ruleId
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

- **ruleId** *string* - Rule ID. *(required)*

## Response

Returns `ProxyRule` object.
## More Info

Get a proxy rule by its unique ID.
