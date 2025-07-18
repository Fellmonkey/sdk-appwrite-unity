# Chat

## Example

```csharp
using Appwrite;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ChatExample : MonoBehaviour
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
        
        await ExampleChat();
    }
    
    async UniTask ExampleChat()
    {
        try
        {
            // Setup parameters
            var prompt = "<PROMPT>"; // Prompt. A string containing questions asked to the AI assistant.
            
            var result = await client.Assistant.ChatAsync(
                prompt
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

- **prompt** *string* - Prompt. A string containing questions asked to the AI assistant. *(required)*

## Response

Returns response object.
## More Info

Send a prompt to the AI assistant and receive a response. This endpoint allows you to interact with Appwrite&#039;s AI assistant by sending questions or prompts and receiving helpful responses in real-time through a server-sent events stream. 
