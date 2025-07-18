# UpdateFcmProvider

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateFcmProviderExample : MonoBehaviour
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
        
        await ExampleUpdateFcmProvider();
    }
    
    async UniTask ExampleUpdateFcmProvider()
    {
        try
        {
            // Setup parameters
            var providerId = "<PROVIDER_ID>"; // Provider ID.
            
            var result = await client.Messaging.UpdateFcmProviderAsync(
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
- **serviceAccountJSON** *object* - FCM service account JSON.

## Response

Returns `Provider` object.
## More Info

Update a Firebase Cloud Messaging provider by its unique ID.
