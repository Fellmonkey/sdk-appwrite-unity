# UpdateBucket

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateBucketExample : MonoBehaviour
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
        
        await ExampleUpdateBucket();
    }
    
    async UniTask ExampleUpdateBucket()
    {
        try
        {
            // Setup parameters
            var bucketId = "<BUCKET_ID>"; // Bucket unique ID.
            var name = "<NAME>"; // Bucket name
            
            var result = await client.Storage.UpdateBucketAsync(
                bucketId,
                name
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

- **bucketId** *string* - Bucket unique ID. *(required)*
- **name** *string* - Bucket name *(required)*
- **permissions** *array* - An array of permission strings. By default, the current permissions are inherited. [Learn more about permissions](https://appwrite.io/docs/permissions).
- **fileSecurity** *boolean* - Enables configuring permissions for individual file. A user needs one of file or bucket level permissions to access a file. [Learn more about permissions](https://appwrite.io/docs/permissions).
- **enabled** *boolean* - Is bucket enabled? When set to &#039;disabled&#039;, users cannot access the files in this bucket but Server SDKs with and API key can still access the bucket. No files are lost when this is toggled.
- **maximumFileSize** *integer* - Maximum file size allowed in bytes. Maximum allowed value is 30MB.
- **allowedFileExtensions** *array* - Allowed file extensions. Maximum of 100 extensions are allowed, each 64 characters long.
- **compression** *string* - Compression algorithm choosen for compression. Can be one of none, [gzip](https://en.wikipedia.org/wiki/Gzip), or [zstd](https://en.wikipedia.org/wiki/Zstd), For file size above 20MB compression is skipped even if it&#039;s enabled
- **encryption** *boolean* - Is encryption enabled? For file size above 20MB encryption is skipped even if it&#039;s enabled
- **antivirus** *boolean* - Is virus scanning enabled? For file size above 20MB AntiVirus scanning is skipped even if it&#039;s enabled

## Response

Returns `Bucket` object.
## More Info

Update a storage bucket by its unique ID.
