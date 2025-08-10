# DeleteFile

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteFileExample : MonoBehaviour
{
    private Client client;
    private Storage storage;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        storage = new Storage(client);

        await ExampleDeleteFile();
    }
    
    async UniTask ExampleDeleteFile()
    {
        try
        {
await storage.DeleteFile(
                bucketId: "<BUCKET_ID>",
                fileId: "<FILE_ID>"
            );
            Debug.Log("Success");
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
- **fileId** *string* - File ID. *(required)* 

## Response

Returns response object.
## More Info

Delete a file by its unique ID. Only users with write permissions have access to delete this resource.
