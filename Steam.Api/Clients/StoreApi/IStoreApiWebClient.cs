using Refit;
using Steam.Api.Clients.StoreApi.Configurations;
using Steam.Api.Clients.StoreApi.Responses;
using Steam.Api.Registrations;
using Steam.Api.Registrations.ConfigBuilder;

namespace Steam.Api.Clients.StoreApi
{
    public interface IStoreApiWebClient
    {
        [Get("/appdetails?appids={appId}")]
        Task<string> GetAppDetails([Query][AliasAs("appId")] string appId);
    }

    public static class BootstrapStoreWebClient
    {
        public static ISteamWebClientConfigBuilder AddStoreApiWebClient(this ISteamWebClientConfigBuilder configBuilder)
            => configBuilder.AddHttpClient<IStoreApiWebClient, StoreApiClientConfig>(new StoreApiClientConfigFactory());
    }
}
