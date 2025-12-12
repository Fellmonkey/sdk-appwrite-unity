# Change Log

## 2.3.0
- Added
  - New enums: `Output`, `Theme`, and `Timezone` to support additional API features.

- Changed
  - Improved thread safety in `CookieContainer` by adding locks around cookie operations to prevent race conditions.
  - Replaced null checks with `ReferenceEquals(null, ...)` in `AppwriteManager` for more robust null handling.
  - Replaced reflection-based service instantiation with direct instantiation in `AppwriteManager` for better performance and AOT compatibility.

- Fixed / Chore
  - Added `Scheduled` status to `ExecutionStatus` enum.
  - Minor formatting and whitespace fixes in `AuthenticationFactor.cs` and other files.
  - Normalized end-of-file newlines across multiple files.

## 2.2.0
- Added
  - New enums: `ExecutionStatus` and `ExecutionTrigger` to better model execution lifecycle values.

- Changed
  - `Execution` model updated to use `ExecutionTrigger` and `ExecutionStatus` types instead of raw strings. Serialization now writes enum `.Value` back to maps.
  - Several models now consistently convert JSON arrays to lists using `.Select(x => x.ToString()).ToList()` to avoid nullable conversions and simplify deserialization (examples: `permissions`, `roles`, `factors`, `labels`).
  - `Document`, `Row`, and `Preferences` models now use `map.TryGetValue("data", out var dataValue)` for optional `data` payloads and fall back to the full map when `data` is missing.

- Fixed / Chore
  - Removed unused `using Appwrite.Enums;` imports from multiple service files to reduce warnings and improve clarity.
  - Minor whitespace and EOF newline normalizations across converters, enums and models.

## 2.1.0
- Added
  - Added a new query helper: `Query.OrderRandom()` to request randomized ordering when building queries.

- Chore / Style
  - Normalized end-of-file newlines and minor formatting fixes across multiple model files in `Assets/Runtime/Core/Models/`.

## 2.0.0
* Support version api 1.8.x
* Introduces the `TablesDB` service with support for row operations, including new `Row` and `RowList` models.
* Adds new MFA-related methods to the `Account` service and deprecates older ones; updates documentation with usage examples.
* Adds the `HEAD` method to the `ExecutionMethod` enum and updates the `Execution` model to include `deploymentId`.

## 1.2.0
Last version for api 1.7.x
* Introduces new spatial and range query methods (e.g., `CreatedBetween`, `UpdatedBetween`, `DistanceEqual`, `Intersects`, etc.) to the `Query` class.
* Updates documentation and comments for account token creation methods to clarify user ID handling.
* Fixes a credit card enum value and updates related documentation. (Union_Pay)
* Refactors async lifecycle methods in `AppwriteManager` and `Realtime` to use `.Forget()` instead of `async void`.

## 1.1.0
* Refactored the `AppwriteSetupAssistant` and `AppwriteSetupWindow` to provide more reliable, asynchronous package installation and status refresh, with improved UI feedback and error handling.
  - The setup assistant now prevents concurrent operations and supports callbacks for install completion.
  - The setup window disables UI during asynchronous operations to prevent user interaction while installing.
* Updated `WebAuthComponent` to require `UNI_TASK`.
* Removed the experimental warning from `Databases.cs` and related documentation.
* Updated `AppwriteUtilities` to pass `true` to `Initialize`.
* Updated Unity package versions in the lock file and project version metadata.

## 1.0.0
* Introduced `WebAuthComponent` for handling OAuth2 authentication via deep links on Unity Editor, iOS, Android, and WebGL
* Added platform-specific cookie management
* Implemented WebGL plugin to enable credentials for fetch/XHR
* Updated `CookieContainer` for improved parsing and persistence
* Refactored `Account.CreateOAuth2Session` to use the new authentication flow and set cookies from OAuth callbacks
* Fixed model deserialization for optional fields
* Exposed Realtime channels

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