# GetVariable

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetVariableExample : MonoBehaviour
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
        
        await ExampleGetVariable();
    }
    
    async UniTask ExampleGetVariable()
    {
        try
        {
            // Setup parameters
            var variableId = "<VARIABLE_ID>"; // Variable unique ID.
            
            var result = await client.Project.GetVariableAsync(
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

- **variableId** *string* - Variable unique ID. *(required)*

## Response

Returns `Variable` object.
## More Info

Get a project variable by its unique ID.
