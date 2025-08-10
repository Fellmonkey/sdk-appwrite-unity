# GetQR

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetQRExample : MonoBehaviour
{
    private Client client;
    private Avatars avatars;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        avatars = new Avatars(client);

        await ExampleGetQR();
    }
    
    async UniTask ExampleGetQR()
    {
        try
        {
            byte[] result = await avatars.GetQR(
                text: "<TEXT>",
                size: 1, // optional
                margin: 0, // optional
                download: false // optional
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

- **text** *string* - Plain text to be converted to QR code image. *(required)* 
- **size** *integer* - QR code size. Pass an integer between 1 to 1000. Defaults to 400. *(optional)*
- **margin** *integer* - Margin from edge. Pass an integer between 0 to 10. Defaults to 1. *(optional)*
- **download** *boolean* - Return resulting image with &#039;Content-Disposition: attachment &#039; headers for the browser to start downloading it. Pass 0 for no header, or 1 for otherwise. Default value is set to 0. *(optional)*

## Response

Returns response object.
## More Info

Converts a given plain text to a QR code image. You can use the query parameters to change the size and style of the resulting image.

