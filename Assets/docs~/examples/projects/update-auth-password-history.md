# UpdateAuthPasswordHistory

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateAuthPasswordHistoryExample : MonoBehaviour
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
        
        await ExampleUpdateAuthPasswordHistory();
    }
    
    async UniTask ExampleUpdateAuthPasswordHistory()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var limit = 0; // Set the max number of passwords to store in user history. User can&#039;t choose a new password that is already stored in the password history list.  Max number of passwords allowed in history is20. Default value is 0
            
            var result = await client.Projects.UpdateAuthPasswordHistoryAsync(
                projectId,
                limit
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
- **limit** *integer* - Set the max number of passwords to store in user history. User can&#039;t choose a new password that is already stored in the password history list.  Max number of passwords allowed in history is20. Default value is 0 *(required)*

## Response

Returns `Project` object.
## More Info

Update the authentication password history requirement. Use this endpoint to require new passwords to be different than the last X amount of previously used ones.
