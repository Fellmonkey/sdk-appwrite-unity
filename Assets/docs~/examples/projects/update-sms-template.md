# UpdateSmsTemplate

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateSmsTemplateExample : MonoBehaviour
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
        
        await ExampleUpdateSmsTemplate();
    }
    
    async UniTask ExampleUpdateSmsTemplate()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var type = "verification"; // Template type
            var locale = "af"; // Template locale
            var message = "<MESSAGE>"; // Template message
            
            var result = await client.Projects.UpdateSmsTemplateAsync(
                projectId,
                type,
                locale,
                message
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
- **type** *string* - Template type *(required)*
- **locale** *string* - Template locale *(required)*
- **message** *string* - Template message *(required)*

## Response

Returns `SmsTemplate` object.
## More Info

Update a custom SMS template for the specified locale and type. Use this endpoint to modify the content of your SMS templates. 
