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
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteSession("YOUR_SESSION");
              .SetXAppwriteDevKey("YOUR_DEVKEY");
        
        await ExampleUpdateName();
    }
    
    async UniTask ExampleUpdateName()
    {
        try
        {
            // Setup parameters
            var name = "<NAME>"; // User name. Max length: 128 chars.
            
            var result = await client.Account.UpdateNameAsync(
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

- **name** *string* - User name. Max length: 128 chars. *(required)*

## Response

Returns `User` object.
## More Info

Update currently logged in user account name.
