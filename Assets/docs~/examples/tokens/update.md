# Update

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateExample : MonoBehaviour
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
        
        await ExampleUpdate();
    }
    
    async UniTask ExampleUpdate()
    {
        try
        {
            // Setup parameters
            var tokenId = "<TOKEN_ID>"; // Token unique ID.
            
            var result = await client.Tokens.UpdateAsync(
                tokenId
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

- **tokenId** *string* - Token unique ID. *(required)*
- **expire** *string* - File token expiry date

## Response

Returns `ResourceToken` object.
## More Info

Update a token by its unique ID. Use this endpoint to update a token&#039;s expiry date.
