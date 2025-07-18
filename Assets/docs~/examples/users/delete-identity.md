# DeleteIdentity

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteIdentityExample : MonoBehaviour
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
        
        await ExampleDeleteIdentity();
    }
    
    async UniTask ExampleDeleteIdentity()
    {
        try
        {
            // Setup parameters
            var identityId = "<IDENTITY_ID>"; // Identity ID.
            
            var result = await client.Users.DeleteIdentityAsync(
                identityId
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

- **identityId** *string* - Identity ID. *(required)*

## Response

Returns response object.
## More Info

Delete an identity by its unique ID.
