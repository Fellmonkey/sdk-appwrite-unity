# UpdateName

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateNameExample : MonoBehaviour
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
        
        await ExampleUpdateName();
    }
    
    async UniTask ExampleUpdateName()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var name = "<NAME>"; // User name. Max length: 128 chars.
            
            var result = await client.Users.UpdateNameAsync(
                userId,
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

- **userId** *string* - User ID. *(required)*
- **name** *string* - User name. Max length: 128 chars. *(required)*

## Response

Returns `User` object.
## More Info

Update the user name by its unique ID.
