# UpdateVariable

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateVariableExample : MonoBehaviour
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
        
        await ExampleUpdateVariable();
    }
    
    async UniTask ExampleUpdateVariable()
    {
        try
        {
            // Setup parameters
            var variableId = "<VARIABLE_ID>"; // Variable unique ID.
            var key = "<KEY>"; // Variable key. Max length: 255 chars.
            
            var result = await client.Project.UpdateVariableAsync(
                variableId,
                key
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

- **variableId** *string* - Variable unique ID. *(required)*
- **key** *string* - Variable key. Max length: 255 chars. *(required)*
- **value** *string* - Variable value. Max length: 8192 chars.
- **secret** *boolean* - Secret variables can be updated or deleted, but only projects can read them during build and runtime.

## Response

Returns `Variable` object.
## More Info

Update project variable by its unique ID. This variable will be accessible in all Appwrite Functions at runtime.
