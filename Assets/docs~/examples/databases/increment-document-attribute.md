# IncrementDocumentAttribute

## Example

```csharp
using Appwrite;
using Appwrite.Models;
using Appwrite.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class IncrementDocumentAttributeExample : MonoBehaviour
{
    private Client client;
    private Databases databases;

    async void Start()
    {
        client = new Client()
            .SetEndpoint("https://<REGION>.cloud.appwrite.io/v1") // Your API Endpoint
            .SetProject("<YOUR_PROJECT_ID>"); // Your project ID

        databases = new Databases(client);

        await ExampleIncrementDocumentAttribute();
    }
    
    async UniTask ExampleIncrementDocumentAttribute()
    {
        try
        {
            Document result = await databases.IncrementDocumentAttribute(
                databaseId: "<DATABASE_ID>",
                collectionId: "<COLLECTION_ID>",
                documentId: "<DOCUMENT_ID>",
                attribute: "",
                value: 0, // optional
                max: 0 // optional
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
- **max** *number* - Maximum value for the attribute. If the current value is greater than this value, an error will be thrown. *(optional)*

## Response

Returns `Document` object.
## More Info

Increment a specific attribute of a document by a given value.
