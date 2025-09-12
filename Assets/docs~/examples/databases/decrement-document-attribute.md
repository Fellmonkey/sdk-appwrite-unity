# DecrementDocumentAttribute

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DecrementDocumentAttributeExample : MonoBehaviour
{
    private Client client;
    private Databases databases;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        databases = new Databases(client);

        await ExampleDecrementDocumentAttribute();
    }
    
    async UniTask ExampleDecrementDocumentAttribute()
    {
        try
        {
            Document result = await databases.DecrementDocumentAttribute(
                databaseId: "<DATABASE_ID>",
                collectionId: "<COLLECTION_ID>",
                documentId: "<DOCUMENT_ID>",
                attribute: "",
                value: 0, // optional
                min: 0 // optional
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
- **value** *number* - Value to increment the attribute by. The value must be a number. *(optional)*
- **min** *number* - Minimum value for the attribute. If the current value is lesser than this value, an exception will be thrown. *(optional)*

## Response

Returns `Document` object.
## More Info

Decrement a specific attribute of a document by a given value.
