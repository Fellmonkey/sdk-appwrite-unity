# UpdateOAuth2

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateOAuth2Example : MonoBehaviour
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
        
        await ExampleUpdateOAuth2();
    }
    
    async UniTask ExampleUpdateOAuth2()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var provider = "amazon"; // Provider Name
            
            var result = await client.Projects.UpdateOAuth2Async(
                projectId,
                provider
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

- **projectId** *string* - Project unique ID. *(required)*
- **provider** *string* - Provider Name *(required)*
- **appId** *string* - Provider app ID. Max length: 256 chars.
- **secret** *string* - Provider secret key. Max length: 512 chars.
- **enabled** *boolean* - Provider status. Set to &#039;false&#039; to disable new session creation.

## Response

Returns `Project` object.
## More Info

Update the OAuth2 provider configurations. Use this endpoint to set up or update the OAuth2 provider credentials or enable/disable providers. 
