using Newtonsoft.Json;

namespace Steam.Api.Clients.StoreApi.Responses.JsonConverters
{
    public class RequirementsJsonConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;

        public RequirementsJsonConverter()
        {
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject) 
                return null;

            return serializer.Deserialize<Requirements>(reader);
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
