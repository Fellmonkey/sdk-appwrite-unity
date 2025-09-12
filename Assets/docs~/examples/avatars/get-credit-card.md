# GetCreditCard

## Example

```csharp
using Appwrite;
using Appwrite.Enums;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetCreditCardExample : MonoBehaviour
{
    private Client client;
    private Avatars avatars;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        avatars = new Avatars(client);

        await ExampleGetCreditCard();
    }
    
    async UniTask ExampleGetCreditCard()
    {
        try
        {
            byte[] result = await avatars.GetCreditCard(
                code: CreditCard.AmericanExpress,
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

- **code** *string* - Credit Card Code. Possible values: amex, argencard, cabal, cencosud, diners, discover, elo, hipercard, jcb, mastercard, naranja, targeta-shopping, unionpay, visa, mir, maestro, rupay. *(required)* 
- **width** *integer* - Image width. Pass an integer between 0 to 2000. Defaults to 100. *(optional)*
- **height** *integer* - Image height. Pass an integer between 0 to 2000. Defaults to 100. *(optional)*
- **quality** *integer* - Image quality. Pass an integer between 0 to 100. Defaults to keep existing image quality. *(optional)*

## Response

Returns response object.
## More Info

The credit card endpoint will return you the icon of the credit card provider you need. Use width, height and quality arguments to change the output settings.

When one dimension is specified and the other is 0, the image is scaled with preserved aspect ratio. If both dimensions are 0, the API provides an image at source quality. If dimensions are not specified, the default size of image returned is 100x100px.

