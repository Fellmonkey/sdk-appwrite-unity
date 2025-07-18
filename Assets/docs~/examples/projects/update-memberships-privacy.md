# UpdateMembershipsPrivacy

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateMembershipsPrivacyExample : MonoBehaviour
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
        
        await ExampleUpdateMembershipsPrivacy();
    }
    
    async UniTask ExampleUpdateMembershipsPrivacy()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var userName = false; // Set to true to show userName to members of a team.
            var userEmail = false; // Set to true to show email to members of a team.
            var mfa = false; // Set to true to show mfa to members of a team.
            
            var result = await client.Projects.UpdateMembershipsPrivacyAsync(
                projectId,
                userName,
                userEmail,
                mfa
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
- **userName** *boolean* - Set to true to show userName to members of a team. *(required)*
- **userEmail** *boolean* - Set to true to show email to members of a team. *(required)*
- **mfa** *boolean* - Set to true to show mfa to members of a team. *(required)*

## Response

Returns `Project` object.
## More Info

Update project membership privacy settings. Use this endpoint to control what user information is visible to other team members, such as user name, email, and MFA status. 
