# ListVariables

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListVariablesExample : MonoBehaviour
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
        
        await ExampleListVariables();
    }
    
    async UniTask ExampleListVariables()
    {
        try
        {
            // Setup parameters
            var functionId = "<FUNCTION_ID>"; // Function unique ID.
            
            var result = await client.Functions.ListVariablesAsync(
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

- **functionId** *string* - Function unique ID. *(required)*

## Response

Returns `VariableList` object.
## More Info

Get a list of all variables of a specific function.
