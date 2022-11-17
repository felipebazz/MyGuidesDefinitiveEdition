using Newtonsoft.Json;
using Steam.Api.Clients.StoreApi.Responses.Enums;

namespace Steam.Api.Clients.StoreApi.Responses.JsonConverters
{
    public class ControllerSupportJsonConverter : JsonConverter
    {
        public override bool CanRead => true;


        public ControllerSupportJsonConverter()
        {
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var jsonValue = serializer.Deserialize<string>(reader);

            if (Enum.TryParse(jsonValue, true, out ControllerSupportEnum convertedValue))
            {
                return convertedValue;
            }

            return null;
        }

        public override bool CanConvert(Type t) => t == typeof(ControllerSupportEnum) || t == typeof(ControllerSupportEnum?);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
