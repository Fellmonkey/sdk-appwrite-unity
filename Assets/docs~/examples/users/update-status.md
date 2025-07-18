# UpdateStatus

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateStatusExample : MonoBehaviour
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
        
        await ExampleUpdateStatus();
    }
    
    async UniTask ExampleUpdateStatus()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var status = false; // User Status. To activate the user pass `true` and to block the user pass `false`.
            
            var result = await client.Users.UpdateStatusAsync(
                userId,
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

- **userId** *string* - User ID. *(required)*
- **status** *boolean* - User Status. To activate the user pass `true` and to block the user pass `false`. *(required)*

## Response

Returns `User` object.
## More Info

Update the user status by its unique ID. Use this endpoint as an alternative to deleting a user if you want to keep user&#039;s ID reserved.
