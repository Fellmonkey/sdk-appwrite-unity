# GetFavicon

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetFaviconExample : MonoBehaviour
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
        
        await ExampleGetFavicon();
    }
    
    async UniTask ExampleGetFavicon()
    {
        try
        {
            // Setup parameters
            var url = "https://example.com"; // Website URL which you want to fetch the favicon from.
            
            var result = await client.Avatars.GetFaviconAsync(
                url
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

- **url** *string* - Website URL which you want to fetch the favicon from. *(required)*

## Response

Returns byte array of the file.
## More Info

Use this endpoint to fetch the favorite icon (AKA favicon) of any remote website URL.

This endpoint does not follow HTTP redirects.
