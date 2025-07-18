# UpdatePersonalDataCheck

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePersonalDataCheckExample : MonoBehaviour
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
        
        await ExampleUpdatePersonalDataCheck();
    }
    
    async UniTask ExampleUpdatePersonalDataCheck()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var enabled = false; // Set whether or not to check a password for similarity with personal data. Default is false.
            
            var result = await client.Projects.UpdatePersonalDataCheckAsync(
                projectId,
                enabled
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
- **enabled** *boolean* - Set whether or not to check a password for similarity with personal data. Default is false. *(required)*

## Response

Returns `Project` object.
## More Info

Enable or disable checking user passwords against their personal data. This helps prevent users from using personal information in their passwords. 
