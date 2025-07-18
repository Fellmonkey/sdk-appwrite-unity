# DeleteVariable

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteVariableExample : MonoBehaviour
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
        
        await ExampleDeleteVariable();
    }
    
    async UniTask ExampleDeleteVariable()
    {
        try
        {
            // Setup parameters
            var siteId = "<SITE_ID>"; // Site unique ID.
            var variableId = "<VARIABLE_ID>"; // Variable unique ID.
            
            var result = await client.Sites.DeleteVariableAsync(
                siteId,
                variableId
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

- **siteId** *string* - Site unique ID. *(required)*
- **variableId** *string* - Variable unique ID. *(required)*

## Response

Returns response object.
## More Info

Delete a variable by its unique ID.
