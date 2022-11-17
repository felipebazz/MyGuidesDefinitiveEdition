using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Steam.Api.Clients.StoreApi.Responses.JsonConverters
{
    public class TestConverter : JsonConverter
    {
        public TestConverter()
        {

        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var jsonData = reader.Value.ToString();
            var test = JToken.Parse(jsonData).First.First;

            return test["data"].ToObject<SteamApp>();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
