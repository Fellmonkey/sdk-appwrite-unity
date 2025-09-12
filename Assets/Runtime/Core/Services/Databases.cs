#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Appwrite.Models;
using Appwrite.Enums;

namespace Appwrite.Services
{
    public class Databases : Service
    {
        public Databases(Client client) : base(client)
        {
        }

        /// <para>
        /// Get a list of all the user's documents in a given collection. You can use
        /// the query params to filter your results.
        /// </para>
        /// </summary>
        [Obsolete("This API has been deprecated since 1.8.0. Please use `TablesDB.listRows` instead.")]
        public UniTask<Models.DocumentList> ListDocuments(string databaseId, string collectionId, List<string>? queries = null)
        {
            var apiPath = "/databases/{databaseId}/collections/{collectionId}/documents"
                .Replace("{databaseId}", databaseId)
                .Replace("{collectionId}", collectionId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.DocumentList Convert(Dictionary<string, object> it) =>
                Models.DocumentList.From(map: it);

            return _client.Call<Models.DocumentList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Create a new Document. Before using this route, you should create a new
        /// collection resource using either a [server
        /// integration](https://appwrite.io/docs/server/databases#databasesCreateCollection)
        /// API or directly from your database console.
        /// </para>
        /// </summary>
        [Obsolete("This API has been deprecated since 1.8.0. Please use `TablesDB.createRow` instead.")]
        public UniTask<Models.Document> CreateDocument(string databaseId, string collectionId, string documentId, object data, List<string>? permissions = null)
        {
            var apiPath = "/databases/{databaseId}/collections/{collectionId}/documents"
                .Replace("{databaseId}", databaseId)
                .Replace("{collectionId}", collectionId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "documentId", documentId },
                { "data", data },
                { "permissions", permissions }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Document Convert(Dictionary<string, object> it) =>
                Models.Document.From(map: it);

            return _client.Call<Models.Document>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Get a document by its unique ID. This endpoint response returns a JSON
        /// object with the document data.
        /// </para>
        /// </summary>
        [Obsolete("This API has been deprecated since 1.8.0. Please use `TablesDB.getRow` instead.")]
        public UniTask<Models.Document> GetDocument(string databaseId, string collectionId, string documentId, List<string>? queries = null)
        {
            var apiPath = "/databases/{databaseId}/collections/{collectionId}/documents/{documentId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{collectionId}", collectionId)
                .Replace("{documentId}", documentId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.Document Convert(Dictionary<string, object> it) =>
                Models.Document.From(map: it);

            return _client.Call<Models.Document>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Create or update a Document. Before using this route, you should create a
        /// new collection resource using either a [server
        /// integration](https://appwrite.io/docs/server/databases#databasesCreateCollection)
        /// API or directly from your database console.
        /// </para>
        /// </summary>
        [Obsolete("This API has been deprecated since 1.8.0. Please use `TablesDB.upsertRow` instead.")]
        public UniTask<Models.Document> UpsertDocument(string databaseId, string collectionId, string documentId, object data, List<string>? permissions = null)
        {
            var apiPath = "/databases/{databaseId}/collections/{collectionId}/documents/{documentId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{collectionId}", collectionId)
                .Replace("{documentId}", documentId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "data", data },
                { "permissions", permissions }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Document Convert(Dictionary<string, object> it) =>
                Models.Document.From(map: it);

            return _client.Call<Models.Document>(
                method: "PUT",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Update a document by its unique ID. Using the patch method you can pass
        /// only specific fields that will get updated.
        /// </para>
        /// </summary>
        [Obsolete("This API has been deprecated since 1.8.0. Please use `TablesDB.updateRow` instead.")]
        public UniTask<Models.Document> UpdateDocument(string databaseId, string collectionId, string documentId, object? data = null, List<string>? permissions = null)
        {
            var apiPath = "/databases/{databaseId}/collections/{collectionId}/documents/{documentId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{collectionId}", collectionId)
                .Replace("{documentId}", documentId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "data", data },
                { "permissions", permissions }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Document Convert(Dictionary<string, object> it) =>
                Models.Document.From(map: it);

            return _client.Call<Models.Document>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Delete a document by its unique ID.
        /// </para>
        /// </summary>
        [Obsolete("This API has been deprecated since 1.8.0. Please use `TablesDB.deleteRow` instead.")]
        public UniTask<object> DeleteDocument(string databaseId, string collectionId, string documentId)
        {
            var apiPath = "/databases/{databaseId}/collections/{collectionId}/documents/{documentId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{collectionId}", collectionId)
                .Replace("{documentId}", documentId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };



            return _client.Call<object>(
                method: "DELETE",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!);

        }

        /// <para>
        /// Decrement a specific attribute of a document by a given value.
        /// </para>
        /// </summary>
        [Obsolete("This API has been deprecated since 1.8.0. Please use `TablesDB.decrementRowColumn` instead.")]
        public UniTask<Models.Document> DecrementDocumentAttribute(string databaseId, string collectionId, string documentId, string attribute, double? xvalue = null, double? min = null)
        {
            var apiPath = "/databases/{databaseId}/collections/{collectionId}/documents/{documentId}/{attribute}/decrement"
                .Replace("{databaseId}", databaseId)
                .Replace("{collectionId}", collectionId)
                .Replace("{documentId}", documentId)
                .Replace("{attribute}", attribute);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "value", xvalue },
                { "min", min }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Document Convert(Dictionary<string, object> it) =>
                Models.Document.From(map: it);

            return _client.Call<Models.Document>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Increment a specific attribute of a document by a given value.
        /// </para>
        /// </summary>
        [Obsolete("This API has been deprecated since 1.8.0. Please use `TablesDB.incrementRowColumn` instead.")]
        public UniTask<Models.Document> IncrementDocumentAttribute(string databaseId, string collectionId, string documentId, string attribute, double? xvalue = null, double? max = null)
        {
            var apiPath = "/databases/{databaseId}/collections/{collectionId}/documents/{documentId}/{attribute}/increment"
                .Replace("{databaseId}", databaseId)
                .Replace("{collectionId}", collectionId)
                .Replace("{documentId}", documentId)
                .Replace("{attribute}", attribute);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "value", xvalue },
                { "max", max }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Document Convert(Dictionary<string, object> it) =>
                Models.Document.From(map: it);

            return _client.Call<Models.Document>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

    }
}
#endif