# GetImage

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetImageExample : MonoBehaviour
{
    private Client client;
    private Avatars avatars;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        avatars = new Avatars(client);

        await ExampleGetImage();
    }
    
    async UniTask ExampleGetImage()
    {
        try
        {
            byte[] result = await avatars.GetImage(
                url: "https://example.com",
                width: 0, // optional
                height: 0 // optional
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

- **url** *string* - Image URL which you want to crop. *(required)* 
- **width** *integer* - Resize preview image width, Pass an integer between 0 to 2000. Defaults to 400. *(optional)*
- **height** *integer* - Resize preview image height, Pass an integer between 0 to 2000. Defaults to 400. *(optional)*

## Response

Returns response object.
## More Info

Use this endpoint to fetch a remote image URL and crop it to any image size you want. This endpoint is very useful if you need to crop and display remote images in your app or in case you want to make sure a 3rd party image is properly served using a TLS protocol.

When one dimension is specified and the other is 0, the image is scaled with preserved aspect ratio. If both dimensions are 0, the API provides an image at source quality. If dimensions are not specified, the default size of image returned is 400x400px.

This endpoint does not follow HTTP redirects.
