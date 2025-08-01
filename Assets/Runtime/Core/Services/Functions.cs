#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Appwrite.Models;
using Appwrite.Enums;

namespace Appwrite.Services
{
    public class Functions : Service
    {
        public Functions(Client client) : base(client)
        {
        }

        /// <para>
        /// Get a list of all the current user function execution logs. You can use the
        /// query params to filter your results.
        /// </para>
        /// </summary>
        public UniTask<Models.ExecutionList> ListExecutions(string functionId, List<string>? queries = null)
        {
            var apiPath = "/functions/{functionId}/executions"
                .Replace("{functionId}", functionId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.ExecutionList Convert(Dictionary<string, object> it) =>
                Models.ExecutionList.From(map: it);

            return _client.Call<Models.ExecutionList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Trigger a function execution. The returned object will return you the
        /// current execution status. You can ping the `Get Execution` endpoint to get
        /// updates on the current execution status. Once this endpoint is called, your
        /// function execution process will start asynchronously.
        /// </para>
        /// </summary>
        public UniTask<Models.Execution> CreateExecution(string functionId, string? body = null, bool? xasync = null, string? xpath = null, Appwrite.Enums.ExecutionMethod? method = null, object? headers = null, string? scheduledAt = null)
        {
            var apiPath = "/functions/{functionId}/executions"
                .Replace("{functionId}", functionId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "body", body },
                { "async", xasync },
                { "path", xpath },
                { "method", method?.Value },
                { "headers", headers },
                { "scheduledAt", scheduledAt }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Execution Convert(Dictionary<string, object> it) =>
                Models.Execution.From(map: it);

            return _client.Call<Models.Execution>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <para>
        /// Get a function execution log by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<Models.Execution> GetExecution(string functionId, string executionId)
        {
            var apiPath = "/functions/{functionId}/executions/{executionId}"
                .Replace("{functionId}", functionId)
                .Replace("{executionId}", executionId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.Execution Convert(Dictionary<string, object> it) =>
                Models.Execution.From(map: it);

            return _client.Call<Models.Execution>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

    }
}
#endif