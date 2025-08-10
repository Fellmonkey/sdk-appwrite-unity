# ListCountries

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ListCountriesExample : MonoBehaviour
{
    private Client client;
    private Locale locale;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        locale = new Locale(client);

        await ExampleListCountries();
    }
    
    async UniTask ExampleListCountries()
    {
        try
        {
            CountryList result = await locale.ListCountries();

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


## Response

Returns `CountryList` object.
## More Info

List of all countries. You can use the locale header to get the data in a supported language.
