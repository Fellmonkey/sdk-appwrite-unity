# GetFileDownload

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetFileDownloadExample : MonoBehaviour
{
    private Client client;
    private Storage storage;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        storage = new Storage(client);

        await ExampleGetFileDownload();
    }
    
    async UniTask ExampleGetFileDownload()
    {
        try
        {
            byte[] result = await storage.GetFileDownload(
                bucketId: "<BUCKET_ID>",
                fileId: "<FILE_ID>",
                token: "<TOKEN>" // optional
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

- **bucketId** *string* - Storage bucket ID. You can create a new storage bucket using the Storage service [server integration](https://appwrite.io/docs/server/storage#createBucket). *(required)* 
- **fileId** *string* - File ID. *(required)* 
- **token** *string* - File token for accessing this file. *(optional)*

## Response

Returns response object.
## More Info

Get a file content by its unique ID. The endpoint response return with a &#039;Content-Disposition: attachment&#039; header that tells the browser to start downloading the file to user downloads directory.
