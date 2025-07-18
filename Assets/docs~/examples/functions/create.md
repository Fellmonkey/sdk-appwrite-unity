# Create

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateExample : MonoBehaviour
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
        
        await ExampleCreate();
    }
    
    async UniTask ExampleCreate()
    {
        try
        {
            // Setup parameters
            var functionId = "<FUNCTION_ID>"; // Function ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var name = "<NAME>"; // Function name. Max length: 128 chars.
            var runtime = "node-14.5"; // Execution runtime.
            
            var result = await client.Functions.CreateAsync(
                functionId,
                name,
                runtime
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

- **functionId** *string* - Function ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **name** *string* - Function name. Max length: 128 chars. *(required)*
- **runtime** *string* - Execution runtime. *(required)*
- **execute** *array* - An array of role strings with execution permissions. By default no user is granted with any execute permissions. [learn more about roles](https://appwrite.io/docs/permissions#permission-roles). Maximum of 100 roles are allowed, each 64 characters long.
- **events** *array* - Events list. Maximum of 100 events are allowed.
- **schedule** *string* - Schedule CRON syntax.
- **timeout** *integer* - Function maximum execution time in seconds.
- **enabled** *boolean* - Is function enabled? When set to &#039;disabled&#039;, users cannot access the function but Server SDKs with and API key can still access the function. No data is lost when this is toggled.
- **logging** *boolean* - When disabled, executions will exclude logs and errors, and will be slightly faster.
- **entrypoint** *string* - Entrypoint File. This path is relative to the &quot;providerRootDirectory&quot;.
- **commands** *string* - Build Commands.
- **scopes** *array* - List of scopes allowed for API key auto-generated for every execution. Maximum of 100 scopes are allowed.
- **installationId** *string* - Appwrite Installation ID for VCS (Version Control System) deployment.
- **providerRepositoryId** *string* - Repository ID of the repo linked to the function.
- **providerBranch** *string* - Production branch for the repo linked to the function.
- **providerSilentMode** *boolean* - Is the VCS (Version Control System) connection in silent mode for the repo linked to the function? In silent mode, comments will not be made on commits and pull requests.
- **providerRootDirectory** *string* - Path to function code in the linked repo.
- **specification** *string* - Runtime specification for the function and builds.

## Response

Returns `Function` object.
## More Info

Create a new function. You can pass a list of [permissions](https://appwrite.io/docs/permissions) to allow different project users or team with access to execute the function using the client API.
