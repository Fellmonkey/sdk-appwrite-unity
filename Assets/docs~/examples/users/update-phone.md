# UpdatePhone

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdatePhoneExample : MonoBehaviour
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
        
        await ExampleUpdatePhone();
    }
    
    async UniTask ExampleUpdatePhone()
    {
        try
        {
            // Setup parameters
            var userId = "<USER_ID>"; // User ID.
            var number = "+12065550100"; // User phone number.
            
            var result = await client.Users.UpdatePhoneAsync(
                userId,
                number
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
- **number** *string* - User phone number. *(required)*

## Response

Returns `User` object.
## More Info

Update the user phone by its unique ID.
