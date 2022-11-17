using Steam.Api.Clients.StoreApi.Responses;

namespace Steam.Api.Clients.StoreApi
{
    public interface IStoreApiClient
    {
        Task<SteamApp> GetAppDetailsFromStore(string appId);
    }
}
