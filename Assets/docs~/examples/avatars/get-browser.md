# GetBrowser

## Example

```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetBrowserExample : MonoBehaviour
{
    private Client client;
    private Avatars avatars;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        avatars = new Avatars(client);

        await ExampleGetBrowser();
    }
    
    async UniTask ExampleGetBrowser()
    {
        try
        {
            byte[] result = await avatars.GetBrowser(
                code: Browser.AvantBrowser,
                width: 0, // optional
                height: 0, // optional
                quality: -1 // optional
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

- **code** *string* - Browser Code. *(required)* 
- **width** *integer* - Image width. Pass an integer between 0 to 2000. Defaults to 100. *(optional)*
- **height** *integer* - Image height. Pass an integer between 0 to 2000. Defaults to 100. *(optional)*
- **quality** *integer* - Image quality. Pass an integer between 0 to 100. Defaults to keep existing image quality. *(optional)*

## Response

Returns response object.
## More Info

You can use this endpoint to show different browser icons to your users. The code argument receives the browser code as it appears in your user [GET /account/sessions](https://appwrite.io/docs/references/cloud/client-web/account#getSessions) endpoint. Use width, height and quality arguments to change the output settings.

When one dimension is specified and the other is 0, the image is scaled with preserved aspect ratio. If both dimensions are 0, the API provides an image at source quality. If dimensions are not specified, the default size of image returned is 100x100px.
