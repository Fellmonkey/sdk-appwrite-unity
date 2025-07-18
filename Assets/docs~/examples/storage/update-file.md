# UpdateFile

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateFileExample : MonoBehaviour
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
        
        await ExampleUpdateFile();
    }
    
    async UniTask ExampleUpdateFile()
    {
        try
        {
            // Setup parameters
            var bucketId = "<BUCKET_ID>"; // Storage bucket unique ID. You can create a new storage bucket using the Storage service [server integration](https://appwrite.io/docs/server/storage#createBucket).
            var fileId = "<FILE_ID>"; // File unique ID.
            
            var result = await client.Storage.UpdateFileAsync(
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

- **bucketId** *string* - Storage bucket unique ID. You can create a new storage bucket using the Storage service [server integration](https://appwrite.io/docs/server/storage#createBucket). *(required)*
- **fileId** *string* - File unique ID. *(required)*
- **name** *string* - Name of the file
- **permissions** *array* - An array of permission string. By default, the current permissions are inherited. [Learn more about permissions](https://appwrite.io/docs/permissions).

## Response

Returns `File` object.
## More Info

Update a file by its unique ID. Only users with write permissions have access to update this resource.
