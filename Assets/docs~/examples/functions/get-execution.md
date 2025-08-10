# GetExecution

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetExecutionExample : MonoBehaviour
{
    private Client client;
    private Functions functions;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        functions = new Functions(client);

        await ExampleGetExecution();
    }
    
    async UniTask ExampleGetExecution()
    {
        try
        {
            Execution result = await functions.GetExecution(
                functionId: "<FUNCTION_ID>",
                executionId: "<EXECUTION_ID>"
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

- **functionId** *string* - Function ID. *(required)* 
- **executionId** *string* - Execution ID. *(required)* 

## Response

Returns `Execution` object.
## More Info

Get a function execution log by its unique ID.
