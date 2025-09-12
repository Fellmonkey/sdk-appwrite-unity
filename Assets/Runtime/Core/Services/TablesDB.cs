#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Appwrite.Models;
using Appwrite.Enums;

namespace Appwrite.Services
{
    public class TablesDB : Service
    {
        public TablesDB(Client client) : base(client)
        {
        }

        /// <para>
        /// Get a list of all the user's rows in a given table. You can use the query
        /// params to filter your results.
        /// </para>
        /// </summary>
        public UniTask<Models.RowList> ListRows(string databaseId, string tableId, List<string>? queries = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.RowList Convert(Dictionary<string, object> it) =>
                Models.RowList.From(map: it);

            return _client.Call<Models.RowList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Create a new Row. Before using this route, you should create a new table
        /// resource using either a [server
        /// integration](https://appwrite.io/docs/server/tablesdb#tablesDBCreateTable)
        /// API or directly from your database console.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> CreateRow(string databaseId, string tableId, string rowId, object data, List<string>? permissions = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "rowId", rowId },
                { "data", data },
                { "permissions", permissions }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Get a row by its unique ID. This endpoint response returns a JSON object
        /// with the row data.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> GetRow(string databaseId, string tableId, string rowId, List<string>? queries = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Create or update a Row. Before using this route, you should create a new
        /// table resource using either a [server
        /// integration](https://appwrite.io/docs/server/tablesdb#tablesDBCreateTable)
        /// API or directly from your database console.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> UpsertRow(string databaseId, string tableId, string rowId, object? data = null, List<string>? permissions = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "data", data },
                { "permissions", permissions }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "PUT",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Update a row by its unique ID. Using the patch method you can pass only
        /// specific fields that will get updated.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> UpdateRow(string databaseId, string tableId, string rowId, object? data = null, List<string>? permissions = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "data", data },
                { "permissions", permissions }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Delete a row by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<object> DeleteRow(string databaseId, string tableId, string rowId)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId);

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
        /// Decrement a specific column of a row by a given value.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> DecrementRowColumn(string databaseId, string tableId, string rowId, string column, double? xvalue = null, double? min = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}/{column}/decrement"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId)
                .Replace("{column}", column);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "value", xvalue },
                { "min", min }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Increment a specific column of a row by a given value.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> IncrementRowColumn(string databaseId, string tableId, string rowId, string column, double? xvalue = null, double? max = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}/{column}/increment"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId)
                .Replace("{column}", column);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "value", xvalue },
                { "max", max }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

    }
}
#endif