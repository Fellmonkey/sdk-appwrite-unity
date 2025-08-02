using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Appwrite.Models
{
    public class CountryList
    {
        [JsonPropertyName("total")]
        public long Total { get; private set; }

        [JsonPropertyName("countries")]
        public List<Country> Countries { get; private set; }

        public CountryList(
            long total,
            List<Country> countries
        ) {
            Total = total;
            Countries = countries;
        }

        public static CountryList From(Dictionary<string, object> map) => new CountryList(
            total: Convert.ToInt64(map["total"]),
            countries: ((IEnumerable<object>)map["countries"]).Select(it => Country.From(map: (Dictionary<string, object>)it)).ToList()
        );

        public Dictionary<string, object?> ToMap() => new Dictionary<string, object?>()
        {
            { "total", Total },
            { "countries", Countries.Select(it => it.ToMap()) }
        };
    }
}