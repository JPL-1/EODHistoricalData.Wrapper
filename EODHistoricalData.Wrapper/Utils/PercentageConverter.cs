using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace EOD.Utils
{
    /// <summary>
    /// 
    /// </summary>
    internal class PercentageConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal) || objectType == typeof(double) || objectType == typeof(float)
                    || objectType == typeof(decimal?) || objectType == typeof(double?) || objectType == typeof(float?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Null && (objectType == typeof(decimal?) || objectType == typeof(double?) || objectType == typeof(float?)))
                return null;
            else if (token.Type == JTokenType.Float)
                return token.ToObject<decimal>();
            else if (token.Type == JTokenType.String)
            {
                var tokVal = token.ToString().Replace("%", "");
                // Get the value and then we divide by 100 to make is decimal
                if (objectType == typeof(decimal) || objectType == typeof(decimal?))
                    return decimal.Parse(tokVal, System.Globalization.CultureInfo.GetCultureInfo("es-ES")) / 100m;
                if (objectType == typeof(double) || objectType == typeof(double?))
                    return double.Parse(tokVal, System.Globalization.CultureInfo.GetCultureInfo("es-ES")) / 100.0;
                if (objectType == typeof(float) || objectType == typeof(float?))
                    return float.Parse(tokVal, System.Globalization.CultureInfo.GetCultureInfo("es-ES")) / 100.0;

                // Falling through here... will get an exception.
            }
            // Can't handle this value.
            throw new JsonSerializationException("Unexpected token type: " + token.Type.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Does not support writing this property.");
        }
        public override bool CanRead => true;
        public override bool CanWrite => false;
    }
}
