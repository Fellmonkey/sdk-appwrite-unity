using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Appwrite.Models
{
    public class ExecutionList
    {
        [JsonPropertyName("total")]
        public long Total { get; private set; }

        [JsonPropertyName("executions")]
        public List<Execution> Executions { get; private set; }

        public ExecutionList(
            long total,
            List<Execution> executions
        ) {
            Total = total;
            Executions = executions;
        }

        public static ExecutionList From(Dictionary<string, object> map) => new ExecutionList(
            total: Convert.ToInt64(map["total"]),
            executions: ((IEnumerable<object>)map["executions"]).Select(it => Execution.From(map: (Dictionary<string, object>)it)).ToList()
        );

        public Dictionary<string, object?> ToMap() => new Dictionary<string, object?>()
        {
            { "total", Total },
            { "executions", Executions.Select(it => it.ToMap()) }
        };
    }
}
