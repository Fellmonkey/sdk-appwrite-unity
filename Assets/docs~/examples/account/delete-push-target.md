# DeletePushTarget

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeletePushTargetExample : MonoBehaviour
{
    private Client client;
    private Account account;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        account = new Account(client);

        await ExampleDeletePushTarget();
    }
    
    async UniTask ExampleDeletePushTarget()
    {
        try
        {
await account.DeletePushTarget(
                targetId: "<TARGET_ID>"
            );
            Debug.Log("Success");
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

## Response

Returns response object.
## More Info

Delete a push notification target for the currently logged in user. After deletion, the device will no longer receive push notifications. The target must exist and belong to the current user.
