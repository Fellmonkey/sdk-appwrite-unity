# GetBrowser

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetBrowserExample : MonoBehaviour
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
        
        await ExampleGetBrowser();
    }
    
    async UniTask ExampleGetBrowser()
    {
        try
        {
            // Setup parameters
            var code = "aa"; // Browser Code.
            
            var result = await client.Avatars.GetBrowserAsync(
                code
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
- **width** *integer* - Image width. Pass an integer between 0 to 2000. Defaults to 100.
- **height** *integer* - Image height. Pass an integer between 0 to 2000. Defaults to 100.
- **quality** *integer* - Image quality. Pass an integer between 0 to 100. Defaults to keep existing image quality.

## Response

Returns byte array of the file.
## More Info

You can use this endpoint to show different browser icons to your users. The code argument receives the browser code as it appears in your user [GET /account/sessions](https://appwrite.io/docs/references/cloud/client-web/account#getSessions) endpoint. Use width, height and quality arguments to change the output settings.

When one dimension is specified and the other is 0, the image is scaled with preserved aspect ratio. If both dimensions are 0, the API provides an image at source quality. If dimensions are not specified, the default size of image returned is 100x100px.
