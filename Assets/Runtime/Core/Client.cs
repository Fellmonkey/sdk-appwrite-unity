using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
#if UNI_TASK
using Cysharp.Threading.Tasks;
#endif
using UnityEngine;
using UnityEngine.Networking;
using Appwrite.Converters;
using Appwrite.Extensions;
using Appwrite.Models;

namespace Appwrite
{
    public class Client
    {
        public string Endpoint => _endpoint;
        public Dictionary<string, string> Config => _config;

        private readonly Dictionary<string, string> _headers;
        private readonly Dictionary<string, string> _config;
        private string _endpoint;
        private bool _selfSigned;
        private readonly CookieContainer _cookieContainer;

        private static readonly int ChunkSize = 5 * 1024 * 1024;

        public static JsonSerializerOptions DeserializerOptions { get; set; } = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                new ValueClassConverter(),
                new ObjectToInferredTypesConverter()
            }
        };

        public static JsonSerializerOptions SerializerOptions { get; set; } = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                new ValueClassConverter(),
                new ObjectToInferredTypesConverter()
            }
        };

        public Client(
            string endpoint = "https://cloud.appwrite.io/v1",
            bool selfSigned = false)
        {
            _endpoint = endpoint;
            _selfSigned = selfSigned;
            _cookieContainer = new CookieContainer();

            _headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" },
                { "user-agent" , $"AppwriteUnitySDK/0.0.1 ({Environment.OSVersion.Platform}; {Environment.OSVersion.VersionString})"},
                { "x-sdk-name", "NAME" },
                { "x-sdk-platform", "" },
                { "x-sdk-language", "unity" },
                { "x-sdk-version", "0.0.1"},
                { "X-Appwrite-Response-Format", "1.6.0" }
            };

            _config = new Dictionary<string, string>();
        }

        public Client SetSelfSigned(bool selfSigned)
        {
            _selfSigned = selfSigned;
            return this;
        }

        public Client SetEndpoint(string endpoint)
        {
            if (!endpoint.StartsWith("http://") && !endpoint.StartsWith("https://")) {
                throw new AppwriteException("Invalid endpoint URL: " + endpoint);
            }

            _endpoint = endpoint;
            return this;
        }
#if UNI_TASK
        /// <summary>
        /// Sends a "ping" request to Appwrite to verify connectivity.
        /// </summary>
        /// <returns>Ping response as string</returns>
        public async UniTask<string> Ping()
        {
            var headers = new Dictionary<string, string>
            {
                ["content-type"] = "application/json"
            };

            var parameters = new Dictionary<string, object?>();

            return await Call<string>("GET", "/ping", headers, parameters, 
                response => (response.TryGetValue("result", out var result) ? result?.ToString() : null) ?? string.Empty);
        }
#endif
        /// <summary>
        /// Set realtime endpoint for WebSocket connections
        /// </summary>
        /// <param name="endpointRealtime">Realtime endpoint URL</param>
        /// <returns>Client instance for method chaining</returns>
        public Client SetEndPointRealtime(string endpointRealtime)
        {
            if (!endpointRealtime.StartsWith("ws://") && !endpointRealtime.StartsWith("wss://")) {
                throw new AppwriteException("Invalid realtime endpoint URL: " + endpointRealtime);
            }

            _config["endpointRealtime"] = endpointRealtime;
            return this;
        }

        /// <summary>Your project ID</summary>
        public Client SetProject(string value) {
            _config["project"] = value;
            AddHeader("X-Appwrite-Project", value);

            return this;
        }

        /// <summary>Your secret API key</summary>
        public Client SetKey(string value) {
            _config["key"] = value;
            AddHeader("X-Appwrite-Key", value);

            return this;
        }

        /// <summary>Your secret JSON Web Token</summary>
        public Client SetJWT(string value) {
            _config["jWT"] = value;
            AddHeader("X-Appwrite-JWT", value);

            return this;
        }

        public Client SetLocale(string value) {
            _config["locale"] = value;
            AddHeader("X-Appwrite-Locale", value);

            return this;
        }

        public Client SetMode(string value) {
            _config["mode"] = value;
            AddHeader("X-Appwrite-Mode", value);

            return this;
        }

        
        /// <summary>
        /// Set the current session for authenticated requests
        /// </summary>
        /// <param name="session">Session token</param>
        /// <returns>Client instance for method chaining</returns>
        public Client SetSession(string session)
        {
            _config["session"] = session;
            AddHeader("X-Appwrite-Session", session);
            return this;
        }

        /// <summary>
        /// Initialize OAuth2 authentication flow
        /// </summary>
        /// <param name="provider">OAuth provider name</param>
        /// <param name="success">Success callback URL</param>
        /// <param name="failure">Failure callback URL</param>
        /// <param name="scopes">OAuth scopes</param>
        /// <returns>OAuth URL for authentication</returns>
        public string PrepareOAuth2(string provider, string? success = null, string? failure = null, List<string>? scopes = null)
        {
            var parameters = new Dictionary<string, object?>
            {
                ["provider"] = provider,
                ["success"] = success ?? $"{_endpoint}/auth/oauth2/success",
                ["failure"] = failure ?? $"{_endpoint}/auth/oauth2/failure"
            };

            if (scopes is { Count: > 0 })
            {
                parameters["scopes"] = scopes;
            }

            var queryString = parameters.ToQueryString();
            return $"{_endpoint}/auth/oauth2/{provider}?{queryString}";
        }

        /// <summary>
        /// Get the current session from config
        /// </summary>
        /// <returns>Current session token or null</returns>
        public string GetSession()
        {
            return _config.GetValueOrDefault("session");
        }

        /// <summary>
        /// Get the current JWT from config
        /// </summary>
        /// <returns>Current JWT token or null</returns>
        public string GetJWT()
        {
            return _config.GetValueOrDefault("jwt");
        }

        /// <summary>
        /// Clear session and JWT from client
        /// </summary>
        /// <returns>Client instance for method chaining</returns>
        public Client ClearSession()
        {
            _config.Remove("session");
            _config.Remove("jwt");
            _headers.Remove("X-Appwrite-Session");
            _headers.Remove("X-Appwrite-JWT");
            return this;
        }

        public Client AddHeader(string key, string value)
        {
            _headers[key] = value;
            return this;
        }

        private UnityWebRequest PrepareRequest(
            string method,
            string path,
            Dictionary<string, string> headers,
            Dictionary<string, object?> parameters)
        {
            var methodGet = "GET".Equals(method, StringComparison.OrdinalIgnoreCase);
            var methodPost = "POST".Equals(method, StringComparison.OrdinalIgnoreCase);
            var methodPut = "PUT".Equals(method, StringComparison.OrdinalIgnoreCase);
            var methodPatch = "PATCH".Equals(method, StringComparison.OrdinalIgnoreCase);
            var methodDelete = "DELETE".Equals(method, StringComparison.OrdinalIgnoreCase);

            var queryString = methodGet ?
                "?" + parameters.ToQueryString() :
                string.Empty;

            var url = _endpoint + path + queryString;
            UnityWebRequest request;

            var isMultipart = headers.TryGetValue("Content-Type", out var contentType) && 
                              "multipart/form-data".Equals(contentType, StringComparison.OrdinalIgnoreCase);

            if (isMultipart)
            {
                var form = new List<IMultipartFormSection>();

                foreach (var parameter in parameters)
                {
                    if (parameter.Key == "file" && parameter.Value is InputFile inputFile)
                    {
                        byte[] fileData = {};
                        switch (inputFile.SourceType)
                        {
                            case "path":
                                if (System.IO.File.Exists(inputFile.Path))
                                {
                                    fileData = System.IO.File.ReadAllBytes(inputFile.Path);
                                }
                                break;
                            case "stream":
                                if (inputFile.Data is Stream stream)
                                {
                                    using (var memoryStream = new MemoryStream())
                                    {
                                        stream.CopyTo(memoryStream);
                                        fileData = memoryStream.ToArray();
                                    }
                                }
                                break;
                            case "bytes":
                                fileData = inputFile.Data as byte[] ?? Array.Empty<byte>();
                                break;
                        }

                        form.Add(new MultipartFormFileSection(parameter.Key, fileData, inputFile.Filename, inputFile.MimeType));
                    }
                    else if (parameter.Value is IEnumerable<object> enumerable)
                    {
                        var list = new List<object>(enumerable);
                        for (int index = 0; index < list.Count; index++)
                        {
                            form.Add(new MultipartFormDataSection($"{parameter.Key}[{index}]", list[index]?.ToString() ?? string.Empty));
                        }
                    }
                    else
                    {
                        form.Add(new MultipartFormDataSection(parameter.Key, parameter.Value?.ToString() ?? string.Empty));
                    }
                }

                request = UnityWebRequest.Post(url, form);
            }
            else if (methodGet)
            {
                request = UnityWebRequest.Get(url);
            }
            else
            {
                string body = parameters.ToJson();
                byte[] bodyData = Encoding.UTF8.GetBytes(body);

                if (methodPost)
                {
                    request = new UnityWebRequest(url, "POST");
                    request.uploadHandler = new UploadHandlerRaw(bodyData);
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Content-Type", "application/json");
                }
                else if (methodPut)
                    request = UnityWebRequest.Put(url, bodyData);
                else if (methodPatch)
                {
                    request = new UnityWebRequest(url, "PATCH");
                    request.uploadHandler = new UploadHandlerRaw(bodyData);
                    request.downloadHandler = new DownloadHandlerBuffer();
                }
                else if (methodDelete)
                {
                    request = new UnityWebRequest(url, "DELETE");
                    request.uploadHandler = new UploadHandlerRaw(bodyData);
                    request.downloadHandler = new DownloadHandlerBuffer();
                }
                else
                {
                    request = new UnityWebRequest(url, method);
                    request.uploadHandler = new UploadHandlerRaw(bodyData);
                    request.downloadHandler = new DownloadHandlerBuffer();
                }
            }

            // Add default headers
            foreach (var header in _headers)
            {
                if (!header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase) || !isMultipart)
                {
                    request.SetRequestHeader(header.Key, header.Value);
                }
            }

            // Add specific headers
            foreach (var header in headers)
            {
                if (!header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase) || !isMultipart)
                {
                    request.SetRequestHeader(header.Key, header.Value);
                }
            }

            // Add cookies
            var uri = new Uri(url);
            var cookieHeader = _cookieContainer.GetCookieHeader(uri.Host, uri.AbsolutePath);
            if (!string.IsNullOrEmpty(cookieHeader))
            {
                request.SetRequestHeader("Cookie", cookieHeader);
            }

            // Handle self-signed certificates
            if (_selfSigned)
            {
                request.certificateHandler = new AcceptAllCertificatesSignedWithASpecificKeyPublicKey();
            }

            return request;
        }
#if UNI_TASK
        public async UniTask<string> Redirect(
            string method,
            string path,
            Dictionary<string, string> headers,
            Dictionary<string, object?> parameters)
        {
            var request = PrepareRequest(method, path, headers, parameters);
            request.redirectLimit = 0; // Disable auto-redirect

            var operation = request.SendWebRequest();
            
            while (!operation.isDone)
            {
                await UniTask.Yield();
            }

            var code = (int)request.responseCode;

            if (code >= 400)
            {
                var text = request.downloadHandler?.text ?? string.Empty;
                var message = "";
                var type = "";

                var contentType = request.GetResponseHeader("Content-Type") ?? string.Empty;

                if (contentType.Contains("application/json"))
                {
                    try
                    {
                        using var errorDoc = JsonDocument.Parse(text);
                        message = errorDoc.RootElement.GetProperty("message").GetString() ?? "";
                        if (errorDoc.RootElement.TryGetProperty("type", out var typeElement))
                        {
                            type = typeElement.GetString() ?? "";
                        }
                    }
                    catch
                    {
                        message = text;
                    }
                }
                else
                {
                    message = text;
                }

                request.Dispose();
                throw new AppwriteException(message, code, type, text);
            }

            var location = request.GetResponseHeader("Location") ?? string.Empty;
            request.Dispose();
            return location;
        }

        public UniTask<Dictionary<string, object?>> Call(
            string method,
            string path,
            Dictionary<string, string> headers,
            Dictionary<string, object?> parameters)
        {
            return Call<Dictionary<string, object?>>(method, path, headers, parameters);
        }

        public async UniTask<T> Call<T>(
            string method,
            string path,
            Dictionary<string, string> headers,
            Dictionary<string, object?> parameters,
            Func<Dictionary<string, object>, T>? convert = null) where T : class
        {
            var request = PrepareRequest(method, path, headers, parameters);

            var operation = request.SendWebRequest();
            
            while (!operation.isDone)
            {
                await UniTask.Yield();
            }

            var code = (int)request.responseCode;

            // Handle Set-Cookie headers
            var setCookieHeader = request.GetResponseHeader("Set-Cookie");
            if (!string.IsNullOrEmpty(setCookieHeader))
            {
                var uri = new Uri(request.url);
                _cookieContainer.ParseSetCookieHeader(setCookieHeader, uri.Host);
            }

            // Check for warnings
            var warning = request.GetResponseHeader("x-appwrite-warning");
            if (!string.IsNullOrEmpty(warning))
            {
                Debug.LogWarning("Warning: " + warning);
            }

            var contentType = request.GetResponseHeader("Content-Type") ?? string.Empty;
            var isJson = contentType.Contains("application/json");

            if (code >= 400)
            {
                var text = request.downloadHandler?.text ?? string.Empty;
                var message = "";
                var type = "";

                if (isJson)
                {
                    try
                    {
                        using var errorDoc = JsonDocument.Parse(text);
                        message = errorDoc.RootElement.GetProperty("message").GetString() ?? "";
                        if (errorDoc.RootElement.TryGetProperty("type", out var typeElement))
                        {
                            type = typeElement.GetString() ?? "";
                        }
                    }
                    catch
                    {
                        message = text;
                    }
                }
                else
                {
                    message = text;
                }

                request.Dispose();
                throw new AppwriteException(message, code, type, text);
            }

            if (isJson)
            {
                var responseString = request.downloadHandler.text;

                var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(
                    responseString,
                    DeserializerOptions);

                request.Dispose();

                if (convert != null && dict != null)
                {
                    return convert(dict);
                }

                return (dict as T)!;
            }
            else
            {
                var result = request.downloadHandler.data as T;
                request.Dispose();
                return result!;
            }
        }

        public async UniTask<T> ChunkedUpload<T>(
            string path,
            Dictionary<string, string> headers,
            Dictionary<string, object?> parameters,
            Func<Dictionary<string, object>, T> converter,
            string paramName,
            string? idParamName = null,
            Action<UploadProgress>? onProgress = null) where T : class
        {
            if (string.IsNullOrEmpty(paramName))
                throw new ArgumentException("Parameter name cannot be null or empty", nameof(paramName));
                
            if (!parameters.ContainsKey(paramName))
                throw new ArgumentException($"Parameter {paramName} not found", nameof(paramName));
                
            var input = parameters[paramName] as InputFile;
            if (input == null)
                throw new ArgumentException($"Parameter {paramName} must be an InputFile", nameof(paramName));
                
            var size = 0L;
            switch(input.SourceType)
            {
                case "path":
                    var info = new FileInfo(input.Path);
                    input.Data = info.OpenRead();
                    size = info.Length;
                    break;
                case "stream":
                    var stream = input.Data as Stream;
                    if (stream == null)
                        throw new InvalidOperationException("Stream data is null");
                    size = stream.Length;
                    break;
                case "bytes":
                    var bytes = input.Data as byte[];
                    if (bytes == null)
                        throw new InvalidOperationException("Byte array data is null");
                    size = bytes.Length;
                    break;
            };

            var offset = 0L;
            var buffer = new byte[Math.Min(size, ChunkSize)];
            var result = new Dictionary<string, object?>();

            if (size < ChunkSize)
            {
                switch(input.SourceType)
                {
                    case "path":
                    case "stream":
                        var dataStream = input.Data as Stream;
                        if (dataStream == null)
                            throw new InvalidOperationException("Stream data is null");
                        await dataStream.ReadAsync(buffer, 0, (int)size);
                        break;
                    case "bytes":
                        var dataBytes = input.Data as byte[];
                        if (dataBytes == null)
                            throw new InvalidOperationException("Byte array data is null");
                        buffer = dataBytes;
                        break;
                }

                var multipartHeaders = new Dictionary<string, string>(headers)
                {
                    ["Content-Type"] = "multipart/form-data"
                };

                var multipartParameters = new Dictionary<string, object?>(parameters);
                multipartParameters[paramName] = new InputFile 
                { 
                    Data = buffer, 
                    Filename = input.Filename, 
                    MimeType = input.MimeType, 
                    SourceType = "bytes" 
                };

                return await Call(
                    method: "POST",
                    path,
                    multipartHeaders,
                    multipartParameters,
                    converter
                );
            }

            if (!string.IsNullOrEmpty(idParamName))
            {
                try
                {
                    // Make a request to check if a file already exists
                    var current = await Call<Dictionary<string, object?>>(
                        method: "GET",
                        path: $"{path}/{parameters[idParamName!]}",
                        new Dictionary<string, string> { { "Content-Type", "application/json" } },
                        parameters: new Dictionary<string, object?>()
                    );
                    if (current.TryGetValue("chunksUploaded", out var chunksUploadedValue) && chunksUploadedValue != null)
                    {
                        offset = Convert.ToInt64(chunksUploadedValue) * ChunkSize;
                    }
                }
                catch
                {
                    // ignored as it mostly means file not found
                }
            }

            while (offset < size)
            {
                switch(input.SourceType)
                {
                    case "path":
                    case "stream":
                        var stream = input.Data as Stream;
                        if (stream == null)
                            throw new InvalidOperationException("Stream data is null");
                        stream.Seek(offset, SeekOrigin.Begin);
                        await stream.ReadAsync(buffer, 0, ChunkSize);
                        break;
                    case "bytes":
                        buffer = ((byte[])input.Data)
                            .Skip((int)offset)
                            .Take((int)Math.Min(size - offset, ChunkSize - 1))
                            .ToArray();
                        break;
                }

                var chunkHeaders = new Dictionary<string, string>(headers)
                {
                    ["Content-Type"] = "multipart/form-data",
                    ["Content-Range"] = $"bytes {offset}-{Math.Min(offset + ChunkSize - 1, size - 1)}/{size}"
                };

                var chunkParameters = new Dictionary<string, object?>(parameters);
                chunkParameters[paramName] = new InputFile 
                { 
                    Data = buffer, 
                    Filename = input.Filename, 
                    MimeType = input.MimeType, 
                    SourceType = "bytes" 
                };

                result = await Call<Dictionary<string, object?>>(
                    method: "POST",
                    path,
                    chunkHeaders,
                    chunkParameters
                );

                offset += ChunkSize;

                var id = result.ContainsKey("$id")
                    ? result["$id"]?.ToString() ?? string.Empty
                    : string.Empty;
                var chunksTotal = result.TryGetValue("chunksTotal", out var chunksTotalValue) && chunksTotalValue != null
                    ? Convert.ToInt64(chunksTotalValue)
                    : 0L;
                var chunksUploaded = result.TryGetValue("chunksUploaded", out var chunksUploadedValue) && chunksUploadedValue != null
                    ? Convert.ToInt64(chunksUploadedValue)
                    : 0L;

                headers["x-appwrite-id"] = id;

                onProgress?.Invoke(
                    new UploadProgress(
                        id: id,
                        progress: Math.Min(offset, size) / size * 100,
                        sizeUploaded: Math.Min(offset, size),
                        chunksTotal: chunksTotal,
                        chunksUploaded: chunksUploaded));
            }

            // Convert to non-nullable dictionary for converter
            var nonNullableResult = result.Where(kvp => kvp.Value != null)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value!);
            
            return converter(nonNullableResult);
        }
#endif

    }

    // Custom certificate handler for self-signed certificates
    public class AcceptAllCertificatesSignedWithASpecificKeyPublicKey : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true; // Accept all certificates
        }
    }
}
