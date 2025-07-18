# CreateVariable

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateVariableExample : MonoBehaviour
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
        
        await ExampleCreateVariable();
    }
    
    async UniTask ExampleCreateVariable()
    {
        try
        {
            // Setup parameters
            var functionId = "<FUNCTION_ID>"; // Function unique ID.
            var key = "<KEY>"; // Variable key. Max length: 255 chars.
            var value = "<VALUE>"; // Variable value. Max length: 8192 chars.
            
            var result = await client.Functions.CreateVariableAsync(
                functionId,
                key,
                value
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

- **functionId** *string* - Function unique ID. *(required)*
- **key** *string* - Variable key. Max length: 255 chars. *(required)*
- **value** *string* - Variable value. Max length: 8192 chars. *(required)*
- **secret** *boolean* - Secret variables can be updated or deleted, but only functions can read them during build and runtime.

## Response

Returns `Variable` object.
## More Info

Create a new function environment variable. These variables can be accessed in the function at runtime as environment variables.
