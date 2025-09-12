# CreateExecution

## Example

```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateExecutionExample : MonoBehaviour
{
    private Client client;
    private Functions functions;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        functions = new Functions(client);

        await ExampleCreateExecution();
    }
    
    async UniTask ExampleCreateExecution()
    {
        try
        {
            Execution result = await functions.CreateExecution(
                functionId: "<FUNCTION_ID>",
                body: "<BODY>", // optional
                async: false, // optional
                path: "<PATH>", // optional
                method: ExecutionMethod.GET, // optional
                headers: [object], // optional
                scheduledAt: "<SCHEDULED_AT>" // optional
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
- **body** *string* - HTTP body of execution. Default value is empty string. *(optional)*
- **async** *boolean* - Execute code in the background. Default value is false. *(optional)*
- **path** *string* - HTTP path of execution. Path can include query params. Default value is / *(optional)*
- **method** *string* - HTTP method of execution. Default value is POST. *(optional)*
- **headers** *object* - HTTP headers of execution. Defaults to empty. *(optional)*
- **scheduledAt** *string* - Scheduled execution time in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. DateTime value must be in future with precision in minutes. *(optional)*

## Response

Returns `Execution` object.
## More Info

Trigger a function execution. The returned object will return you the current execution status. You can ping the `Get Execution` endpoint to get updates on the current execution status. Once this endpoint is called, your function execution process will start asynchronously.
