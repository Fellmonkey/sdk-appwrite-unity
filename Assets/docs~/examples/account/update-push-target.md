# UpdatePushTarget

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePushTargetExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleUpdatePushTarget();
    }
    
    async UniTask ExampleUpdatePushTarget()
    {
        try
        {
            Target result = await account.UpdatePushTarget(
                targetId: "<TARGET_ID>",
                identifier: "<IDENTIFIER>"
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

- **targetId** *string* - Target ID. *(required)* 
- **identifier** *string* - The target identifier (token, email, phone etc.) *(required)* 

## Response

Returns `Target` object.
## More Info

Update the currently logged in user&#039;s push notification target. You can modify the target&#039;s identifier (device token) and provider ID (token, email, phone etc.). The target must exist and belong to the current user. If you change the provider ID, notifications will be sent through the new messaging provider instead.
