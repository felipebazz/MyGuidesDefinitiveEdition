using Steam.Api.Clients.StoreApi.Responses;

namespace Steam.Api.Clients.StoreApi
{
    public interface ISteamStoreApiWebClient
    {
        Task<SteamApp> GetAppDetailsFromStore(string appId);
    }
}
