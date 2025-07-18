# CreateDatetimeAttribute

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateDatetimeAttributeExample : MonoBehaviour
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
        
        await ExampleCreateDatetimeAttribute();
    }
    
    async UniTask ExampleCreateDatetimeAttribute()
    {
        try
        {
            // Setup parameters
            var databaseId = "<DATABASE_ID>"; // Database ID.
            var collectionId = "<COLLECTION_ID>"; // Collection ID. You can create a new collection using the Database service [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection).
            var key = ""; // Attribute Key.
            var required = false; // Is attribute required?
            
            var result = await client.Databases.CreateDatetimeAttributeAsync(
                databaseId,
                collectionId,
                key,
                required
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

- **databaseId** *string* - Database ID. *(required)*
- **collectionId** *string* - Collection ID. You can create a new collection using the Database service [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection). *(required)*
- **key** *string* - Attribute Key. *(required)*
- **required** *boolean* - Is attribute required? *(required)*
- **default** *string* - Default value for the attribute in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. Cannot be set when attribute is required.
- **array** *boolean* - Is attribute an array?

## Response

Returns `AttributeDatetime` object.
## More Info

Create a date time attribute according to the ISO 8601 standard.
