# GetQR

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetQRExample : MonoBehaviour
{
    private Client client;
    
    async void Start()
    {
        client = gameObject.AddComponent<Client>();
        client.SetEndpoint("https://cloud.appwrite.io/v1")
              .SetXAppwriteProject("YOUR_PROJECT");
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteSession("YOUR_SESSION");
              .SetXAppwriteDevKey("YOUR_DEVKEY");
        
        await ExampleGetQR();
    }
    
    async UniTask ExampleGetQR()
    {
        try
        {
            // Setup parameters
            var text = "<TEXT>"; // Plain text to be converted to QR code image.
            
            var result = await client.Avatars.GetQRAsync(
                text
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
- **size** *integer* - QR code size. Pass an integer between 1 to 1000. Defaults to 400.
- **margin** *integer* - Margin from edge. Pass an integer between 0 to 10. Defaults to 1.
- **download** *boolean* - Return resulting image with &#039;Content-Disposition: attachment &#039; headers for the browser to start downloading it. Pass 0 for no header, or 1 for otherwise. Default value is set to 0.

## Response

Returns byte array of the file.
## More Info

Converts a given plain text to a QR code image. You can use the query parameters to change the size and style of the resulting image.

