# UpdateTelesignProvider

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateTelesignProviderExample : MonoBehaviour
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
        
        await ExampleUpdateTelesignProvider();
    }
    
    async UniTask ExampleUpdateTelesignProvider()
    {
        try
        {
            // Setup parameters
            var providerId = "<PROVIDER_ID>"; // Provider ID.
            
            var result = await client.Messaging.UpdateTelesignProviderAsync(
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
- **customerId** *string* - Telesign customer ID.
- **apiKey** *string* - Telesign API key.
- **from** *string* - Sender number.

## Response

Returns `Provider` object.
## More Info

Update a Telesign provider by its unique ID.
