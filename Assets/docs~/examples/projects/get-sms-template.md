# GetSmsTemplate

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetSmsTemplateExample : MonoBehaviour
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
        
        await ExampleGetSmsTemplate();
    }
    
    async UniTask ExampleGetSmsTemplate()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var type = "verification"; // Template type
            var locale = "af"; // Template locale
            
            var result = await client.Projects.GetSmsTemplateAsync(
                projectId,
                type,
                locale
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

## Response

Returns `SmsTemplate` object.
## More Info

Get a custom SMS template for the specified locale and type returning it&#039;s contents.
