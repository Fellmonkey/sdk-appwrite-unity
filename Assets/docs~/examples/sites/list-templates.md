# ListTemplates

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListTemplatesExample : MonoBehaviour
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
        
        await ExampleListTemplates();
    }
    
    async UniTask ExampleListTemplates()
    {
        try
        {
            var result = await client.Sites.ListTemplatesAsync(
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

- **frameworks** *array* - List of frameworks allowed for filtering site templates. Maximum of 100 frameworks are allowed.
- **useCases** *array* - List of use cases allowed for filtering site templates. Maximum of 100 use cases are allowed.
- **limit** *integer* - Limit the number of templates returned in the response. Default limit is 25, and maximum limit is 5000.
- **offset** *integer* - Offset the list of returned templates. Maximum offset is 5000.

## Response

Returns `TemplateSiteList` object.
## More Info

List available site templates. You can use template details in [createSite](/docs/references/cloud/server-nodejs/sites#create) method.
