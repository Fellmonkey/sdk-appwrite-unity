# GetFilePreview

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetFilePreviewExample : MonoBehaviour
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
        
        await ExampleGetFilePreview();
    }
    
    async UniTask ExampleGetFilePreview()
    {
        try
        {
            // Setup parameters
            var bucketId = "<BUCKET_ID>"; // Storage bucket unique ID. You can create a new storage bucket using the Storage service [server integration](https://appwrite.io/docs/server/storage#createBucket).
            var fileId = "<FILE_ID>"; // File ID
            
            var result = await client.Storage.GetFilePreviewAsync(
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
- **fileId** *string* - File ID *(required)*
- **width** *integer* - Resize preview image width, Pass an integer between 0 to 4000.
- **height** *integer* - Resize preview image height, Pass an integer between 0 to 4000.
- **gravity** *string* - Image crop gravity. Can be one of center,top-left,top,top-right,left,right,bottom-left,bottom,bottom-right
- **quality** *integer* - Preview image quality. Pass an integer between 0 to 100. Defaults to keep existing image quality.
- **borderWidth** *integer* - Preview image border in pixels. Pass an integer between 0 to 100. Defaults to 0.
- **borderColor** *string* - Preview image border color. Use a valid HEX color, no # is needed for prefix.
- **borderRadius** *integer* - Preview image border radius in pixels. Pass an integer between 0 to 4000.
- **opacity** *number* - Preview image opacity. Only works with images having an alpha channel (like png). Pass a number between 0 to 1.
- **rotation** *integer* - Preview image rotation in degrees. Pass an integer between -360 and 360.
- **background** *string* - Preview image background color. Only works with transparent images (png). Use a valid HEX color, no # is needed for prefix.
- **output** *string* - Output format type (jpeg, jpg, png, gif and webp).
- **token** *string* - File token for accessing this file.

## Response

Returns byte array of the file.
## More Info

Get a file preview image. Currently, this method supports preview for image files (jpg, png, and gif), other supported formats, like pdf, docs, slides, and spreadsheets, will return the file icon image. You can also pass query string arguments for cutting and resizing your preview image. Preview is supported only for image files smaller than 10MB.
