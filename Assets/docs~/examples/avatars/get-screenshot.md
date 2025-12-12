# GetScreenshot

## Example

```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetScreenshotExample : MonoBehaviour
{
    private Client client;
    private Avatars avatars;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        avatars = new Avatars(client);

        await ExampleGetScreenshot();
    }
    
    async UniTask ExampleGetScreenshot()
    {
        try
        {
            byte[] result = await avatars.GetScreenshot(
                url: "https://example.com",
                headers: new {
        Authorization = "Bearer token123",
        X-Custom-Header = "value"
    }, // optional
                viewportWidth: 1920, // optional
                viewportHeight: 1080, // optional
                scale: 2, // optional
                theme: theme.Light, // optional
                userAgent: "Mozilla/5.0 (iPhone; CPU iPhone OS 14_0 like Mac OS X) AppleWebKit/605.1.15", // optional
                fullpage: true, // optional
                locale: "en-US", // optional
                timezone: timezone.AfricaAbidjan, // optional
                latitude: 37.7749, // optional
                longitude: -122.4194, // optional
                accuracy: 100, // optional
                touch: true, // optional
                permissions: ["geolocation","notifications"], // optional
                sleep: 3, // optional
                width: 800, // optional
                height: 600, // optional
                quality: 85, // optional
                output: output.Jpg // optional
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

- **url** *string* - Website URL which you want to capture. *(required)* 
- **headers** *object* - HTTP headers to send with the browser request. Defaults to empty. *(optional)*
- **viewportWidth** *integer* - Browser viewport width. Pass an integer between 1 to 1920. Defaults to 1280. *(optional)*
- **viewportHeight** *integer* - Browser viewport height. Pass an integer between 1 to 1080. Defaults to 720. *(optional)*
- **scale** *number* - Browser scale factor. Pass a number between 0.1 to 3. Defaults to 1. *(optional)*
- **theme** *string* - Browser theme. Pass &quot;light&quot; or &quot;dark&quot;. Defaults to &quot;light&quot;. *(optional)*
- **userAgent** *string* - Custom user agent string. Defaults to browser default. *(optional)*
- **fullpage** *boolean* - Capture full page scroll. Pass 0 for viewport only, or 1 for full page. Defaults to 0. *(optional)*
- **locale** *string* - Browser locale (e.g., &quot;en-US&quot;, &quot;fr-FR&quot;). Defaults to browser default. *(optional)*
- **timezone** *string* - IANA timezone identifier (e.g., &quot;America/New_York&quot;, &quot;Europe/London&quot;). Defaults to browser default. *(optional)*
- **latitude** *number* - Geolocation latitude. Pass a number between -90 to 90. Defaults to 0. *(optional)*
- **longitude** *number* - Geolocation longitude. Pass a number between -180 to 180. Defaults to 0. *(optional)*
- **accuracy** *number* - Geolocation accuracy in meters. Pass a number between 0 to 100000. Defaults to 0. *(optional)*
- **touch** *boolean* - Enable touch support. Pass 0 for no touch, or 1 for touch enabled. Defaults to 0. *(optional)*
- **permissions** *array* - Browser permissions to grant. Pass an array of permission names like [&quot;geolocation&quot;, &quot;camera&quot;, &quot;microphone&quot;]. Defaults to empty. *(optional)*
- **sleep** *integer* - Wait time in seconds before taking the screenshot. Pass an integer between 0 to 10. Defaults to 0. *(optional)*
- **width** *integer* - Output image width. Pass 0 to use original width, or an integer between 1 to 2000. Defaults to 0 (original width). *(optional)*
- **height** *integer* - Output image height. Pass 0 to use original height, or an integer between 1 to 2000. Defaults to 0 (original height). *(optional)*
- **quality** *integer* - Screenshot quality. Pass an integer between 0 to 100. Defaults to keep existing image quality. *(optional)*
- **output** *string* - Output format type (jpeg, jpg, png, gif and webp). *(optional)*

## Response

Returns response object.
## More Info

Use this endpoint to capture a screenshot of any website URL. This endpoint uses a headless browser to render the webpage and capture it as an image.

You can configure the browser viewport size, theme, user agent, geolocation, permissions, and more. Capture either just the viewport or the full page scroll.

When width and height are specified, the image is resized accordingly. If both dimensions are 0, the API provides an image at original size. If dimensions are not specified, the default viewport size is 1280x720px.
