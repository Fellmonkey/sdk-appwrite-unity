# GetFilePreview

## Example

```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetFilePreviewExample : MonoBehaviour
{
    private Client client;
    private Storage storage;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        storage = new Storage(client);

        await ExampleGetFilePreview();
    }
    
    async UniTask ExampleGetFilePreview()
    {
        try
        {
            byte[] result = await storage.GetFilePreview(
                bucketId: "<BUCKET_ID>",
                fileId: "<FILE_ID>",
                width: 0, // optional
                height: 0, // optional
                gravity: ImageGravity.Center, // optional
                quality: -1, // optional
                borderWidth: 0, // optional
                borderColor: "", // optional
                borderRadius: 0, // optional
                opacity: 0, // optional
                rotation: -360, // optional
                background: "", // optional
                output: ImageFormat.Jpg, // optional
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

- **bucketId** *string* - Storage bucket unique ID. You can create a new storage bucket using the Storage service [server integration](https://appwrite.io/docs/server/storage#createBucket). *(required)* 
- **fileId** *string* - File ID *(required)* 
- **width** *integer* - Resize preview image width, Pass an integer between 0 to 4000. *(optional)*
- **height** *integer* - Resize preview image height, Pass an integer between 0 to 4000. *(optional)*
- **gravity** *string* - Image crop gravity. Can be one of center,top-left,top,top-right,left,right,bottom-left,bottom,bottom-right *(optional)*
- **quality** *integer* - Preview image quality. Pass an integer between 0 to 100. Defaults to keep existing image quality. *(optional)*
- **borderWidth** *integer* - Preview image border in pixels. Pass an integer between 0 to 100. Defaults to 0. *(optional)*
- **borderColor** *string* - Preview image border color. Use a valid HEX color, no # is needed for prefix. *(optional)*
- **borderRadius** *integer* - Preview image border radius in pixels. Pass an integer between 0 to 4000. *(optional)*
- **opacity** *number* - Preview image opacity. Only works with images having an alpha channel (like png). Pass a number between 0 to 1. *(optional)*
- **rotation** *integer* - Preview image rotation in degrees. Pass an integer between -360 and 360. *(optional)*
- **background** *string* - Preview image background color. Only works with transparent images (png). Use a valid HEX color, no # is needed for prefix. *(optional)*
- **output** *string* - Output format type (jpeg, jpg, png, gif and webp). *(optional)*
- **token** *string* - File token for accessing this file. *(optional)*

## Response

Returns response object.
## More Info

Get a file preview image. Currently, this method supports preview for image files (jpg, png, and gif), other supported formats, like pdf, docs, slides, and spreadsheets, will return the file icon image. You can also pass query string arguments for cutting and resizing your preview image. Preview is supported only for image files smaller than 10MB.
