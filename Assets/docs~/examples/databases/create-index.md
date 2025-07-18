# CreateIndex

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CreateIndexExample : MonoBehaviour
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
        
        await ExampleCreateIndex();
    }
    
    async UniTask ExampleCreateIndex()
    {
        try
        {
            // Setup parameters
            var databaseId = "<DATABASE_ID>"; // Database ID.
            var collectionId = "<COLLECTION_ID>"; // Collection ID. You can create a new collection using the Database service [server integration](https://appwrite.io/docs/server/databases#databasesCreateCollection).
            var key = ""; // Index Key.
            var type = "key"; // Index type.
            var attributes = new List<string>(); // Array of attributes to index. Maximum of 100 attributes are allowed, each 32 characters long.
            
            var result = await client.Databases.CreateIndexAsync(
                databaseId,
                collectionId,
                key,
                type,
                attributes
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
- **key** *string* - Index Key. *(required)*
- **type** *string* - Index type. *(required)*
- **attributes** *array* - Array of attributes to index. Maximum of 100 attributes are allowed, each 32 characters long. *(required)*
- **orders** *array* - Array of index orders. Maximum of 100 orders are allowed.
- **lengths** *array* - Length of index. Maximum of 100

## Response

Returns `Index` object.
## More Info

Creates an index on the attributes listed. Your index should include all the attributes you will query in a single request.
Attributes can be `key`, `fulltext`, and `unique`.
