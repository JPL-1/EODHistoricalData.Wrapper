using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EOD.Utils
{
    /// <summary>
    /// 
    /// </summary>
    internal class SafeNumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal) || objectType == typeof(double) || objectType == typeof(float)
                    || objectType == typeof(decimal?) || objectType == typeof(double?) || objectType == typeof(float?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            var isNullable = objectType == typeof(decimal?) || objectType == typeof(double?) || objectType == typeof(float?);
            if (token.Type == JTokenType.Null && isNullable)
                return null;
            else if (token.Type == JTokenType.Float)
                return (object) objectType == typeof(double) || objectType == typeof(double?) ? token.ToObject<double>()
                     : (object) objectType == typeof(float) || objectType == typeof(float?) ? token.ToObject<float>()
                     : (object) token.ToObject<decimal>();
            else if (token.Type == JTokenType.String)
            {
                // Found some values of 'No Data' coming back from the API
                var sTok = token.ToString();
                if (sTok == "No Data" && isNullable)
                    return null;

                var allowedChars = new List<char> { '-', '.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'E', 'e' };
                var tokVal = new string(token.ToString().ToCharArray()
                                            .Where(x => allowedChars.Contains(x))
                                            .ToArray());

                if ((string.IsNullOrEmpty(tokVal) || tokVal == "-") && isNullable) 
                    return null;

                // Get the value and then we divide by 100 to make is decimal
                if (objectType == typeof(decimal) || objectType == typeof(decimal?))
                    return decimal.Parse(tokVal, System.Globalization.CultureInfo.GetCultureInfo("es-ES"));
                if (objectType == typeof(double) || objectType == typeof(double?))
                    return double.Parse(tokVal, System.Globalization.CultureInfo.GetCultureInfo("es-ES"));
                if (objectType == typeof(float) || objectType == typeof(float?))
                    return float.Parse(tokVal, System.Globalization.CultureInfo.GetCultureInfo("es-ES"));

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
