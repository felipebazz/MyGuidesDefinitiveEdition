using Refit;
using Steam.Api.Clients.StoreApi.Configurations;
using Steam.Api.Registrations;
using Steam.Api.Registrations.ConfigBuilder;
using Steam.Api.Responses;

namespace Steam.Api.Clients.StoreApi
{
    public interface StoreApiWebClient
    {
        [Get("/ISteamUserStats/GetSchemaForGame/v2?key={apiKey}&appId={appId}")]
        Task<SchemaForGameResponse> GetSchemaForGameAsync([Query][AliasAs("apiKey")] string apiKey, [Query][AliasAs("appId")] string appId);
    }

    public static class BootstrapStoreWebClient
    {
        public static ISteamWebClientConfigBuilder AddStoreApiWebClient(this ISteamWebClientConfigBuilder configBuilder)
            => configBuilder.AddHttpClient<StoreApiWebClient, StoreApiClientConfig>(new StoreApiClientConfigFactory());
    }
}
