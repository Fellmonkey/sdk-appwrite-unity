# GetInstallation

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GetInstallationExample : MonoBehaviour
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
        
        await ExampleGetInstallation();
    }
    
    async UniTask ExampleGetInstallation()
    {
        try
        {
            // Setup parameters
            var installationId = "<INSTALLATION_ID>"; // Installation Id
            
            var result = await client.Vcs.GetInstallationAsync(
                installationId
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

- **installationId** *string* - Installation Id *(required)*

## Response

Returns `Installation` object.
## More Info

Get a VCS installation by its unique ID. This endpoint returns the installation&#039;s details including its provider, organization, and configuration. 
