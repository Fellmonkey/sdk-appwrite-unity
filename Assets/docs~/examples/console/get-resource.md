# GetResource

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetResourceExample : MonoBehaviour
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
        
        await ExampleGetResource();
    }
    
    async UniTask ExampleGetResource()
    {
        try
        {
            // Setup parameters
            var value = "<VALUE>"; // Resource value.
            var type = "rules"; // Resource type.
            
            var result = await client.Console.GetResourceAsync(
                value,
                type
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

- **value** *string* - Resource value. *(required)*
- **type** *string* - Resource type. *(required)*

## Response

Returns response object.
## More Info

Check if a resource ID is available.
