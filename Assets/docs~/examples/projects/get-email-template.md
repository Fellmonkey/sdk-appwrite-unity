# GetEmailTemplate

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetEmailTemplateExample : MonoBehaviour
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
        
        await ExampleGetEmailTemplate();
    }
    
    async UniTask ExampleGetEmailTemplate()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var type = "verification"; // Template type
            var locale = "af"; // Template locale
            
            var result = await client.Projects.GetEmailTemplateAsync(
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

Returns `EmailTemplate` object.
## More Info

Get a custom email template for the specified locale and type. This endpoint returns the template content, subject, and other configuration details. 
