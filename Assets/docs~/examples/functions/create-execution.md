# CreateExecution

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateExecutionExample : MonoBehaviour
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
        
        await ExampleCreateExecution();
    }
    
    async UniTask ExampleCreateExecution()
    {
        try
        {
            // Setup parameters
            var functionId = "<FUNCTION_ID>"; // Function ID.
            
            var result = await client.Functions.CreateExecutionAsync(
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

- **functionId** *string* - Function ID. *(required)*
- **body** *string* - HTTP body of execution. Default value is empty string.
- **async** *boolean* - Execute code in the background. Default value is false.
- **path** *string* - HTTP path of execution. Path can include query params. Default value is /
- **method** *string* - HTTP method of execution. Default value is GET.
- **headers** *object* - HTTP headers of execution. Defaults to empty.
- **scheduledAt** *string* - Scheduled execution time in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. DateTime value must be in future with precision in minutes.

## Response

Returns `Execution` object.
## More Info

Trigger a function execution. The returned object will return you the current execution status. You can ping the `Get Execution` endpoint to get updates on the current execution status. Once this endpoint is called, your function execution process will start asynchronously.
