# Create

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateExample : MonoBehaviour
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
        
        await ExampleCreate();
    }
    
    async UniTask ExampleCreate()
    {
        try
        {
            // Setup parameters
            var projectId = ""; // Unique Id. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, and hyphen. Can&#039;t start with a special char. Max length is 36 chars.
            var name = "<NAME>"; // Project name. Max length: 128 chars.
            var teamId = "<TEAM_ID>"; // Team unique ID.
            
            var result = await client.Projects.CreateAsync(
                projectId,
                name,
                teamId
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

- **projectId** *string* - Unique Id. Choose a custom ID or generate a random ID with `ID.unique()`. Valid chars are a-z, and hyphen. Can&#039;t start with a special char. Max length is 36 chars. *(required)*
- **name** *string* - Project name. Max length: 128 chars. *(required)*
- **teamId** *string* - Team unique ID. *(required)*
- **region** *string* - Project Region.
- **description** *string* - Project description. Max length: 256 chars.
- **logo** *string* - Project logo.
- **url** *string* - Project URL.
- **legalName** *string* - Project legal Name. Max length: 256 chars.
- **legalCountry** *string* - Project legal Country. Max length: 256 chars.
- **legalState** *string* - Project legal State. Max length: 256 chars.
- **legalCity** *string* - Project legal City. Max length: 256 chars.
- **legalAddress** *string* - Project legal Address. Max length: 256 chars.
- **legalTaxId** *string* - Project legal Tax ID. Max length: 256 chars.

## Response

Returns `Project` object.
## More Info

Create a new project. You can create a maximum of 100 projects per account. 
