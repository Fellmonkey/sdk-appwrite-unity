# CreateApnsProvider

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateApnsProviderExample : MonoBehaviour
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
        
        await ExampleCreateApnsProvider();
    }
    
    async UniTask ExampleCreateApnsProvider()
    {
        try
        {
            // Setup parameters
            var providerId = "<PROVIDER_ID>"; // Provider ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars.
            var name = "<NAME>"; // Provider name.
            
            var result = await client.Messaging.CreateApnsProviderAsync(
                providerId,
                name
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

- **providerId** *string* - Provider ID. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **name** *string* - Provider name. *(required)*
- **authKey** *string* - APNS authentication key.
- **authKeyId** *string* - APNS authentication key ID.
- **teamId** *string* - APNS team ID.
- **bundleId** *string* - APNS bundle ID.
- **sandbox** *boolean* - Use APNS sandbox environment.
- **enabled** *boolean* - Set as enabled.

## Response

Returns `Provider` object.
## More Info

Create a new Apple Push Notification service provider.
