# Mutation

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MutationExample : MonoBehaviour
{
    private Client client;
    private Graphql graphql;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        graphql = new Graphql(client);

        await ExampleMutation();
    }
    
    async UniTask ExampleMutation()
    {
        try
        {
            Any result = await graphql.Mutation(
                query: [object]
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

- **query** *object* - The query or queries to execute. *(required)* 

## Response

Returns response object.
## More Info

Execute a GraphQL mutation.
