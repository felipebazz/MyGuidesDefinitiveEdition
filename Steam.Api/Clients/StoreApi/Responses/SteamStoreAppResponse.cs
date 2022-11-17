using Newtonsoft.Json;
using Steam.Api.Clients.StoreApi.Responses.JsonConverters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Steam.Api.Clients.StoreApi.Responses
{
    //[JsonConverter(typeof(TestConverter))]
    //[DataContract(Name = "1491710")]
    public class SteamStoreAppResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public SteamApp Data { get; set; }
    }

    public class HttpResult<TResult>
        where TResult : class
    {
        public TResult SteamApp { get; set; }
    }
}
