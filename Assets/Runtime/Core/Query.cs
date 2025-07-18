using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Appwrite
{
    public class Query
    {
        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;
        
        [JsonPropertyName("attribute")]
        public string? Attribute { get; set; }
        
        [JsonPropertyName("values")]
        public List<object>? Values { get; set; }

        public Query()
        {
        }

        public Query(string method, string? attribute, object? values)
        {
            this.Method = method;
            this.Attribute = attribute;

            if (values is IList valuesList)
            {
                this.Values = new List<object>();
                foreach (var value in valuesList)
                {
                    this.Values.Add(value); // Automatically boxes if value is a value type
                }
            }
            else if (values != null)
            {
                this.Values = new List<object> { values };
            }
        }

        override public string ToString()
        {
            return JsonSerializer.Serialize(this, Client.SerializerOptions);
        }

        public static string Equal(string attribute, object value)
        {
            return new Query("equal", attribute, value).ToString();
        }

        public static string NotEqual(string attribute, object value)
        {
            return new Query("notEqual", attribute, value).ToString();
        }

        public static string LessThan(string attribute, object value)
        {
            return new Query("lessThan", attribute, value).ToString();
        }

        public static string LessThanEqual(string attribute, object value)
        {
            return new Query("lessThanEqual", attribute, value).ToString();
        }

        public static string GreaterThan(string attribute, object value)
        {
            return new Query("greaterThan", attribute, value).ToString();
        }

        public static string GreaterThanEqual(string attribute, object value)
        {
            return new Query("greaterThanEqual", attribute, value).ToString();
        }

        public static string Search(string attribute, string value)
        {
            return new Query("search", attribute, value).ToString();
        }

        public static string IsNull(string attribute)
        {
            return new Query("isNull", attribute, null).ToString();
        }

        public static string IsNotNull(string attribute)
        {
            return new Query("isNotNull", attribute, null).ToString();
        }

        public static string StartsWith(string attribute, string value)
        {
            return new Query("startsWith", attribute, value).ToString();
        }

        public static string EndsWith(string attribute, string value)
        {
            return new Query("endsWith", attribute, value).ToString();
        }

        public static string Between(string attribute, string start, string end)
        {
            return new Query("between", attribute, new List<string> { start, end }).ToString();
        }

        public static string Between(string attribute, int start, int end)
        {
            return new Query("between", attribute, new List<int> { start, end }).ToString();
        }

        public static string Between(string attribute, double start, double end)
        {
            return new Query("between", attribute, new List<double> { start, end }).ToString();
        }

        public static string Select(List<string> attributes)
        {
            return new Query("select", null, attributes).ToString();
        }

        public static string CursorAfter(string documentId)
        {
            return new Query("cursorAfter", null, documentId).ToString();
        }

        public static string CursorBefore(string documentId) {
            return new Query("cursorBefore", null, documentId).ToString();
        }

        public static string OrderAsc(string attribute) {
            return new Query("orderAsc", attribute, null).ToString();
        }

        public static string OrderDesc(string attribute) {
            return new Query("orderDesc", attribute, null).ToString();
        }

        public static string Limit(int limit) {
            return new Query("limit", null, limit).ToString();
        }

        public static string Offset(int offset) {
            return new Query("offset", null, offset).ToString();
        }

        public static string Contains(string attribute, object value) {
            return new Query("contains", attribute, value).ToString();
        }

        public static string Or(List<string> queries) {
            return new Query("or", null, queries.Select(q => JsonSerializer.Deserialize<Query>(q, Client.DeserializerOptions)).ToList()).ToString();
        }

        public static string And(List<string> queries) {
            return new Query("and", null, queries.Select(q => JsonSerializer.Deserialize<Query>(q, Client.DeserializerOptions)).ToList()).ToString();
        }
    }
}