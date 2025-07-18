# CreateStringAttribute

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateStringAttributeExample : MonoBehaviour
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
        
        await ExampleCreateStringAttribute();
    }
    
    async UniTask ExampleCreateStringAttribute()
    {
        try
        {
            // Setup parameters
            var databaseId = "<DATABASE_ID>"; // Database ID.
            var collectionId = "<COLLECTION_ID>"; // Collection ID. You can create a new collection using the Database service [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection).
            var key = ""; // Attribute Key.
            var size = 1; // Attribute size for text attributes, in number of characters.
            var required = false; // Is attribute required?
            
            var result = await client.Databases.CreateStringAttributeAsync(
                databaseId,
                collectionId,
                key,
                size,
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
- **size** *integer* - Attribute size for text attributes, in number of characters. *(required)*
- **required** *boolean* - Is attribute required? *(required)*
- **default** *string* - Default value for attribute when not provided. Cannot be set when attribute is required.
- **array** *boolean* - Is attribute an array?
- **encrypt** *boolean* - Toggle encryption for the attribute. Encryption enhances security by not storing any plain text values in the database. However, encrypted attributes cannot be queried.

## Response

Returns `AttributeString` object.
## More Info

Create a string attribute.

