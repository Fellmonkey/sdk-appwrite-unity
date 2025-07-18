# UpdateAuthStatus

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateAuthStatusExample : MonoBehaviour
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
        
        await ExampleUpdateAuthStatus();
    }
    
    async UniTask ExampleUpdateAuthStatus()
    {
        try
        {
            // Setup parameters
            var projectId = "<PROJECT_ID>"; // Project unique ID.
            var method = "email-password"; // Auth Method. Possible values: email-password,magic-url,email-otp,anonymous,invites,jwt,phone
            var status = false; // Set the status of this auth method.
            
            var result = await client.Projects.UpdateAuthStatusAsync(
                projectId,
                method,
                status
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
- **method** *string* - Auth Method. Possible values: email-password,magic-url,email-otp,anonymous,invites,jwt,phone *(required)*
- **status** *boolean* - Set the status of this auth method. *(required)*

## Response

Returns `Project` object.
## More Info

Update the status of a specific authentication method. Use this endpoint to enable or disable different authentication methods such as email, magic urls or sms in your project. 
