using Newtonsoft.Json;

namespace Steam.Api.Clients.StoreApi.Responses.JsonConverters
{
    public class SteamPriceJsonConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;

        public SteamPriceJsonConverter()
        {
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) 
                return null;

            var price = reader.Value.ToString();

            if (price.Length < 2)
                return double.Parse($".{price}");

            return double.Parse(price.Insert(price.Length - 2, "."));
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
