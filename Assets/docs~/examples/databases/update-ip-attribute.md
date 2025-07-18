# UpdateIpAttribute

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UpdateIpAttributeExample : MonoBehaviour
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
        
        await ExampleUpdateIpAttribute();
    }
    
    async UniTask ExampleUpdateIpAttribute()
    {
        try
        {
            // Setup parameters
            var databaseId = "<DATABASE_ID>"; // Database ID.
            var collectionId = "<COLLECTION_ID>"; // Collection ID. You can create a new collection using the Database service [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection).
            var key = ""; // Attribute Key.
            var required = false; // Is attribute required?
            var default = ""; // Default value for attribute when not provided. Cannot be set when attribute is required.
            
            var result = await client.Databases.UpdateIpAttributeAsync(
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
- **default** *string* - Default value for attribute when not provided. Cannot be set when attribute is required. *(required)*
- **newKey** *string* - New attribute key.

## Response

Returns `AttributeIp` object.
## More Info

Update an ip attribute. Changing the `default` value will not update already existing documents.

