# ListFiles

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListFilesExample : MonoBehaviour
{
    private Client client;
    private Storage storage;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        storage = new Storage(client);

        await ExampleListFiles();
    }
    
    async UniTask ExampleListFiles()
    {
        try
        {
            FileList result = await storage.ListFiles(
                bucketId: "<BUCKET_ID>",
                queries: new List<string>(), // optional
                search: "<SEARCH>", // optional
                total: false // optional
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

- **bucketId** *string* - Storage bucket unique ID. You can create a new storage bucket using the Storage service [server integration](https://appwrite.io/docs/server/storage#createBucket). *(required)* 
- **queries** *array* - Array of query strings generated using the Query class provided by the SDK. [Learn more about queries](https://appwrite.io/docs/queries). Maximum of 100 queries are allowed, each 4096 characters long. You may filter on the following attributes: name, signature, mimeType, sizeOriginal, chunksTotal, chunksUploaded *(optional)*
- **search** *string* - Search term to filter your list results. Max length: 256 chars. *(optional)*
- **total** *boolean* - When set to false, the total count returned will be 0 and will not be calculated. *(optional)*

## Response

Returns `FileList` object.
## More Info

Get a list of all the user files. You can use the query params to filter your results.
