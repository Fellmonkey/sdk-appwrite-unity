# GetFileDownload

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetFileDownloadExample : MonoBehaviour
{
    private Client client;
    
    async void Start()
    {
        client = gameObject.AddComponent<Client>();
        client.SetEndpoint("https://cloud.appwrite.io/v1")
              .SetXAppwriteProject("YOUR_PROJECT");
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteSession("YOUR_SESSION");
              .SetXAppwriteDevKey("YOUR_DEVKEY");
        
        await ExampleGetFileDownload();
    }
    
    async UniTask ExampleGetFileDownload()
    {
        try
        {
            // Setup parameters
            var bucketId = "<BUCKET_ID>"; // Storage bucket ID. You can create a new storage bucket using the Storage service [server integration](https://appwrite.io/docs/server/storage#createBucket).
            var fileId = "<FILE_ID>"; // File ID.
            
            var result = await client.Storage.GetFileDownloadAsync(
                bucketId,
                fileId
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
- **token** *string* - File token for accessing this file.

## Response

Returns byte array of the file.
## More Info

Get a file content by its unique ID. The endpoint response return with a &#039;Content-Disposition: attachment&#039; header that tells the browser to start downloading the file to user downloads directory.
