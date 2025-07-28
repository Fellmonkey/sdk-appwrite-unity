# GetInitials

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetInitialsExample : MonoBehaviour
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
        
        await ExampleGetInitials();
    }
    
    async UniTask ExampleGetInitials()
    {
        try
        {
            var result = await client.Avatars.GetInitialsAsync(
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

- **name** *string* - Full Name. When empty, current user name or email will be used. Max length: 128 chars.
- **width** *integer* - Image width. Pass an integer between 0 to 2000. Defaults to 100.
- **height** *integer* - Image height. Pass an integer between 0 to 2000. Defaults to 100.
- **background** *string* - Changes background color. By default a random color will be picked and stay will persistent to the given name.

## Response

Returns byte array of the file.
## More Info

Use this endpoint to show your user initials avatar icon on your website or app. By default, this route will try to print your logged-in user name or email initials. You can also overwrite the user name if you pass the &#039;name&#039; parameter. If no name is given and no user is logged, an empty avatar will be returned.

You can use the color and background params to change the avatar colors. By default, a random theme will be selected. The random theme will persist for the user&#039;s initials when reloading the same theme will always return for the same initials.

When one dimension is specified and the other is 0, the image is scaled with preserved aspect ratio. If both dimensions are 0, the API provides an image at source quality. If dimensions are not specified, the default size of image returned is 100x100px.

