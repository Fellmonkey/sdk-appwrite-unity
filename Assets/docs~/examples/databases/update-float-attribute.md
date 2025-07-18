# UpdateFloatAttribute

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateFloatAttributeExample : MonoBehaviour
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
        
        await ExampleUpdateFloatAttribute();
    }
    
    async UniTask ExampleUpdateFloatAttribute()
    {
        try
        {
            // Setup parameters
            var databaseId = "<DATABASE_ID>"; // Database ID.
            var collectionId = "<COLLECTION_ID>"; // Collection ID. You can create a new collection using the Database service [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection).
            var key = ""; // Attribute Key.
            var required = false; // Is attribute required?
            var default = 0; // Default value for attribute when not provided. Cannot be set when attribute is required.
            
            var result = await client.Databases.UpdateFloatAttributeAsync(
                databaseId,
                collectionId,
                key,
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
- **required** *boolean* - Is attribute required? *(required)*
- **default** *number* - Default value for attribute when not provided. Cannot be set when attribute is required. *(required)*
- **min** *number* - Minimum value to enforce on new documents
- **max** *number* - Maximum value to enforce on new documents
- **newKey** *string* - New attribute key.

## Response

Returns `AttributeFloat` object.
## More Info

Update a float attribute. Changing the `default` value will not update already existing documents.

