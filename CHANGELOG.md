# Change Log

## 0.5.0
* Added persistent storage for session and JWT in Client
* Implemented persistent cookie storage in CookieContainer with support for max-age, SameSite, and improved domain/path matching
* Refactored model list parsing to handle IEnumerable<object> for better deserialization compatibility
* Updated AppwriteService enum for new service structure and set default realtime endpoint
* Fixed minor formatting and consistency issues across enums and models

## 0.4.0
* Removed server SDK files

## 0.3.0

* Switched to SDK generated for the client (Unity client SDK)
* Previous versions were generated for the server client
* Improved compatibility and usage for Unity client-side applications

## 0.1.0

* Initial release of Appwrite Unity SDK
* SDK auto-generated using custom fork: [Fellmonkey/sdk-generator/tree/unity-client-sdk](https://github.com/Fellmonkey/sdk-generator/tree/unity-client-sdk) (API version 1.7.4)
* Includes core Appwrite services and methods as provided by generator
* Unity-specific improvements:
  * Integration with Unity Editor for easy setup
  * Utility and configuration classes for Unity projects
  * Error handling adapted for Unity
  * Example script for quick start
* Basic documentation and usage examples included