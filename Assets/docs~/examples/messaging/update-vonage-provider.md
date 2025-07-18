# UpdateVonageProvider

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateVonageProviderExample : MonoBehaviour
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
        
        await ExampleUpdateVonageProvider();
    }
    
    async UniTask ExampleUpdateVonageProvider()
    {
        try
        {
            // Setup parameters
            var providerId = "<PROVIDER_ID>"; // Provider ID.
            
            var result = await client.Messaging.UpdateVonageProviderAsync(
                providerId
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

- **providerId** *string* - Provider ID. *(required)*
- **name** *string* - Provider name.
- **enabled** *boolean* - Set as enabled.
- **apiKey** *string* - Vonage API key.
- **apiSecret** *string* - Vonage API secret.
- **from** *string* - Sender number.

## Response

Returns `Provider` object.
## More Info

Update a Vonage provider by its unique ID.
