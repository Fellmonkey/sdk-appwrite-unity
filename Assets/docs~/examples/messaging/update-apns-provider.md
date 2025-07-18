# UpdateApnsProvider

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateApnsProviderExample : MonoBehaviour
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
        
        await ExampleUpdateApnsProvider();
    }
    
    async UniTask ExampleUpdateApnsProvider()
    {
        try
        {
            // Setup parameters
            var providerId = "<PROVIDER_ID>"; // Provider ID.
            
            var result = await client.Messaging.UpdateApnsProviderAsync(
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
- **authKey** *string* - APNS authentication key.
- **authKeyId** *string* - APNS authentication key ID.
- **teamId** *string* - APNS team ID.
- **bundleId** *string* - APNS bundle ID.
- **sandbox** *boolean* - Use APNS sandbox environment.

## Response

Returns `Provider` object.
## More Info

Update a Apple Push Notification service provider by its unique ID.
