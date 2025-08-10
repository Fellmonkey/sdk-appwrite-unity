# ListExecutions

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListExecutionsExample : MonoBehaviour
{
    private Client client;
    private Functions functions;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        functions = new Functions(client);

        await ExampleListExecutions();
    }
    
    async UniTask ExampleListExecutions()
    {
        try
        {
            ExecutionList result = await functions.ListExecutions(
                functionId: "<FUNCTION_ID>",
                queries: new List<string>() // optional
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
- **queries** *array* - Array of query strings generated using the Query class provided by the SDK. [Learn more about queries](https://appwrite.io/docs/queries). Maximum of 100 queries are allowed, each 4096 characters long. You may filter on the following attributes: trigger, status, responseStatusCode, duration, requestMethod, requestPath, deploymentId *(optional)*

## Response

Returns `ExecutionList` object.
## More Info

Get a list of all the current user function execution logs. You can use the query params to filter your results.
