using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Appwrite.Enums;

namespace Appwrite.Converters
{
    public class ValueClassConverter : JsonConverter<object>
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IEnum).IsAssignableFrom(objectType);
        }

        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            var constructor = typeToConvert.GetConstructor(new[] { typeof(string) });
            var obj = constructor?.Invoke(new object[] { value! });

            return Convert.ChangeType(obj, typeToConvert)!;
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            var type = value.GetType();
            var property = type.GetProperty(nameof(IEnum.Value));
            var propertyValue = property?.GetValue(value);

            if (propertyValue == null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStringValue(propertyValue.ToString());
        }
    }
}
