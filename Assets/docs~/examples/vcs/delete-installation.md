# DeleteInstallation

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DeleteInstallationExample : MonoBehaviour
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
        
        await ExampleDeleteInstallation();
    }
    
    async UniTask ExampleDeleteInstallation()
    {
        try
        {
            // Setup parameters
            var installationId = "<INSTALLATION_ID>"; // Installation Id
            
            var result = await client.Vcs.DeleteInstallationAsync(
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

Returns response object.
## More Info

Delete a VCS installation by its unique ID. This endpoint removes the installation and all its associated repositories from the project.
