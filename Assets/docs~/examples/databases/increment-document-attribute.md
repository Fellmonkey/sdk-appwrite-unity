# IncrementDocumentAttribute

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class IncrementDocumentAttributeExample : MonoBehaviour
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
        
        await ExampleIncrementDocumentAttribute();
    }
    
    async UniTask ExampleIncrementDocumentAttribute()
    {
        try
        {
            // Setup parameters
            var databaseId = "<DATABASE_ID>"; // Database ID.
            var collectionId = "<COLLECTION_ID>"; // Collection ID.
            var documentId = "<DOCUMENT_ID>"; // Document ID.
            var attribute = ""; // Attribute key.
            
            var result = await client.Databases.IncrementDocumentAttributeAsync(
                databaseId,
                collectionId,
                documentId,
                attribute
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
- **collectionId** *string* - Collection ID. *(required)*
- **documentId** *string* - Document ID. *(required)*
- **attribute** *string* - Attribute key. *(required)*
- **value** *number* - Value to increment the attribute by. The value must be a number.
- **max** *number* - Maximum value for the attribute. If the current value is greater than this value, an error will be thrown.

## Response

Returns `Document` object.
## More Info

Increment a specific attribute of a document by a given value.
