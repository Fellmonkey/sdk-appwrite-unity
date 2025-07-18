# UpdateAuthPasswordDictionary

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateAuthPasswordDictionaryExample : MonoBehaviour
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
        
        await ExampleUpdateAuthPasswordDictionary();
    }
    
    async UniTask ExampleUpdateAuthPasswordDictionary()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var enabled = false; // Set whether or not to enable checking user&#039;s password against most commonly used passwords. Default is false.
            
            var result = await client.Projects.UpdateAuthPasswordDictionaryAsync(
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
- **enabled** *boolean* - Set whether or not to enable checking user&#039;s password against most commonly used passwords. Default is false. *(required)*

## Response

Returns `Project` object.
## More Info

Enable or disable checking user passwords against common passwords dictionary. This helps ensure users don&#039;t use common and insecure passwords. 
