# GetFlag

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetFlagExample : MonoBehaviour
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
        
        await ExampleGetFlag();
    }
    
    async UniTask ExampleGetFlag()
    {
        try
        {
            // Setup parameters
            var code = "af"; // Country Code. ISO Alpha-2 country code format.
            
            var result = await client.Avatars.GetFlagAsync(
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

- **code** *string* - Country Code. ISO Alpha-2 country code format. *(required)*
- **width** *integer* - Image width. Pass an integer between 0 to 2000. Defaults to 100.
- **height** *integer* - Image height. Pass an integer between 0 to 2000. Defaults to 100.
- **quality** *integer* - Image quality. Pass an integer between 0 to 100. Defaults to keep existing image quality.

## Response

Returns byte array of the file.
## More Info

You can use this endpoint to show different country flags icons to your users. The code argument receives the 2 letter country code. Use width, height and quality arguments to change the output settings. Country codes follow the [ISO 3166-1](https://en.wikipedia.org/wiki/ISO_3166-1) standard.

When one dimension is specified and the other is 0, the image is scaled with preserved aspect ratio. If both dimensions are 0, the API provides an image at source quality. If dimensions are not specified, the default size of image returned is 100x100px.

