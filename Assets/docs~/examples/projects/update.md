# Update

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateExample : MonoBehaviour
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
        
        await ExampleUpdate();
    }
    
    async UniTask ExampleUpdate()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var name = "<NAME>"; // Project name. Max length: 128 chars.
            
            var result = await client.Projects.UpdateAsync(
                projectId,
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

- **projectId** *string* - Project unique ID. *(required)*
- **name** *string* - Project name. Max length: 128 chars. *(required)*
- **description** *string* - Project description. Max length: 256 chars.
- **logo** *string* - Project logo.
- **url** *string* - Project URL.
- **legalName** *string* - Project legal name. Max length: 256 chars.
- **legalCountry** *string* - Project legal country. Max length: 256 chars.
- **legalState** *string* - Project legal state. Max length: 256 chars.
- **legalCity** *string* - Project legal city. Max length: 256 chars.
- **legalAddress** *string* - Project legal address. Max length: 256 chars.
- **legalTaxId** *string* - Project legal tax ID. Max length: 256 chars.

## Response

Returns `Project` object.
## More Info

Update a project by its unique ID.
