# DecrementDocumentAttribute

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DecrementDocumentAttributeExample : MonoBehaviour
{
    private Client client;
    
    async void Start()
    {
        client = gameObject.AddComponent<Client>();
        client.SetEndpoint("https://cloud.appwrite.io/v1")
              .SetXAppwriteProject("YOUR_PROJECT");
              .SetXAppwriteJWT("YOUR_JWT");
              .SetXAppwriteLocale("YOUR_LOCALE");
              .SetXAppwriteSession("YOUR_SESSION");
              .SetXAppwriteDevKey("YOUR_DEVKEY");
        
        await ExampleDecrementDocumentAttribute();
    }
    
    async UniTask ExampleDecrementDocumentAttribute()
    {
        try
        {
            // Setup parameters
            var databaseId = "<DATABASE_ID>"; // Database ID.
            var collectionId = "<COLLECTION_ID>"; // Collection ID.
            var documentId = "<DOCUMENT_ID>"; // Document ID.
            var attribute = ""; // Attribute key.
            
            var result = await client.Databases.DecrementDocumentAttributeAsync(
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
- **value** *number* - Value to decrement the attribute by. The value must be a number.
- **min** *number* - Minimum value for the attribute. If the current value is lesser than this value, an exception will be thrown.

## Response

Returns `Document` object.
## More Info

Decrement a specific attribute of a document by a given value.
