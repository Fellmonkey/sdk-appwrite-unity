# UpdateEnumAttribute

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateEnumAttributeExample : MonoBehaviour
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
        
        await ExampleUpdateEnumAttribute();
    }
    
    async UniTask ExampleUpdateEnumAttribute()
    {
        try
        {
            // Setup parameters
            var databaseId = "<DATABASE_ID>"; // Database ID.
            var collectionId = "<COLLECTION_ID>"; // Collection ID. You can create a new collection using the Database service [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection).
            var key = ""; // Attribute Key.
            var elements = new List<string>(); // Array of elements in enumerated type. Uses length of longest element to determine size. Maximum of 100 elements are allowed, each 255 characters long.
            var required = false; // Is attribute required?
            var default = "<DEFAULT>"; // Default value for attribute when not provided. Cannot be set when attribute is required.
            
            var result = await client.Databases.UpdateEnumAttributeAsync(
                databaseId,
                collectionId,
                key,
                elements,
                required,
                default
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
- **elements** *array* - Array of elements in enumerated type. Uses length of longest element to determine size. Maximum of 100 elements are allowed, each 255 characters long. *(required)*
- **required** *boolean* - Is attribute required? *(required)*
- **default** *string* - Default value for attribute when not provided. Cannot be set when attribute is required. *(required)*
- **newKey** *string* - New attribute key.

## Response

Returns `AttributeEnum` object.
## More Info

Update an enum attribute. Changing the `default` value will not update already existing documents.

