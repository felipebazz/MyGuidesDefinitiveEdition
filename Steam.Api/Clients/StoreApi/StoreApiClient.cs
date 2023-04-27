using Newtonsoft.Json.Linq;
using Steam.Api.Clients.StoreApi.Responses;

namespace Steam.Api.Clients.StoreApi
{
    public class StoreApiClient : ISteamStoreApiWebClient
    {
        private readonly IStoreApiWebClient _storeApi;
        public StoreApiClient(IStoreApiWebClient storeApi)
        {
            _storeApi = storeApi;
        }

        public async Task<SteamApp> GetAppDetailsFromStore(string appId)
        {
            var result = await _storeApi.GetAppDetails(appId);
            var jsonData = JToken.Parse(result).First.First;

            if (!bool.Parse(jsonData["success"].ToString()))
                return null;

            return jsonData["data"].ToObject<SteamApp>();
        }
    }
}
