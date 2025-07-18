# GetBucket

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetBucketExample : MonoBehaviour
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
        
        await ExampleGetBucket();
    }
    
    async UniTask ExampleGetBucket()
    {
        try
        {
            // Setup parameters
            var bucketId = "<BUCKET_ID>"; // Bucket unique ID.
            
            var result = await client.Storage.GetBucketAsync(
                bucketId
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

## Response

Returns `Bucket` object.
## More Info

Get a storage bucket by its unique ID. This endpoint response returns a JSON object with the storage bucket metadata.
