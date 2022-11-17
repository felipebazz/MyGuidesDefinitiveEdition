using Microsoft.Extensions.DependencyInjection;
using Refit;
using Steam.Api.Clients.WebApi.Configurations;
using Steam.Api.Registrations;
using Steam.Api.Registrations.ConfigBuilder;
using Steam.Api.Responses;

namespace Steam.Api.Clients.WebApi
{
    public interface ISteamWebApiClient
    {
        [Get("/ISteamUserStats/GetSchemaForGame/v2?key={apiKey}&appId={appId}")]
        Task<SchemaForGameResponse> GetSchemaForGameAsync([Query][AliasAs("apiKey")] string apiKey, [Query][AliasAs("appId")] string appId);
    }

    public static class BootstrapSteamWebApiClient
    {
        public static ISteamWebClientConfigBuilder AddSteamWebApiClient(this ISteamWebClientConfigBuilder configBuilder)
            => configBuilder.AddHttpClient<ISteamWebApiClient, SteamWebApiClientConfig>(new SteamWebApiClientConfigFactory());
    }
}
