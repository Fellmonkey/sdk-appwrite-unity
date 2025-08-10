# UpdateFile

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateFileExample : MonoBehaviour
{
    private Client client;
    private Storage storage;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        storage = new Storage(client);

        await ExampleUpdateFile();
    }
    
    async UniTask ExampleUpdateFile()
    {
        try
        {
            File result = await storage.UpdateFile(
                bucketId: "<BUCKET_ID>",
                fileId: "<FILE_ID>",
                name: "<NAME>", // optional
                permissions: ["read("any")"] // optional
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
- **name** *string* - Name of the file *(optional)*
- **permissions** *array* - An array of permission string. By default, the current permissions are inherited. [Learn more about permissions](https://appwrite.io/docs/permissions). *(optional)*

## Response

Returns `File` object.
## More Info

Update a file by its unique ID. Only users with write permissions have access to update this resource.
