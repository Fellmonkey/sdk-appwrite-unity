# GetCreditCard

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetCreditCardExample : MonoBehaviour
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
        
        await ExampleGetCreditCard();
    }
    
    async UniTask ExampleGetCreditCard()
    {
        try
        {
            // Setup parameters
            var code = "amex"; // Credit Card Code. Possible values: amex, argencard, cabal, cencosud, diners, discover, elo, hipercard, jcb, mastercard, naranja, targeta-shopping, union-china-pay, visa, mir, maestro, rupay.
            
            var result = await client.Avatars.GetCreditCardAsync(
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

- **code** *string* - Credit Card Code. Possible values: amex, argencard, cabal, cencosud, diners, discover, elo, hipercard, jcb, mastercard, naranja, targeta-shopping, union-china-pay, visa, mir, maestro, rupay. *(required)*
- **width** *integer* - Image width. Pass an integer between 0 to 2000. Defaults to 100.
- **height** *integer* - Image height. Pass an integer between 0 to 2000. Defaults to 100.
- **quality** *integer* - Image quality. Pass an integer between 0 to 100. Defaults to keep existing image quality.

## Response

Returns byte array of the file.
## More Info

The credit card endpoint will return you the icon of the credit card provider you need. Use width, height and quality arguments to change the output settings.

When one dimension is specified and the other is 0, the image is scaled with preserved aspect ratio. If both dimensions are 0, the API provides an image at source quality. If dimensions are not specified, the default size of image returned is 100x100px.

