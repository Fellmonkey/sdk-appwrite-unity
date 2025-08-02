using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Appwrite.Models
{
    public class TeamList
    {
        [JsonPropertyName("total")]
        public long Total { get; private set; }

        [JsonPropertyName("teams")]
        public List<Team> Teams { get; private set; }

        public TeamList(
            long total,
            List<Team> teams
        ) {
            Total = total;
            Teams = teams;
        }

        public static TeamList From(Dictionary<string, object> map) => new TeamList(
            total: Convert.ToInt64(map["total"]),
            teams: ((IEnumerable<object>)map["teams"]).Select(it => Team.From(map: (Dictionary<string, object>)it)).ToList()
        );

        public Dictionary<string, object?> ToMap() => new Dictionary<string, object?>()
        {
            { "total", Total },
            { "teams", Teams.Select(it => it.ToMap()) }
        };
    }
}