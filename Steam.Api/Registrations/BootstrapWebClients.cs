using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using Steam.Api.Abstractions;
using Steam.Api.Clients.StoreApi;
using Steam.Api.Configuration.Clients;
using Steam.Api.Registrations.ConfigBuilder;
using System.Runtime.CompilerServices;

namespace Steam.Api.Registrations
{
    public static class BootstrapWebClients
    {
        internal static HttpClientsContextConfig _httpClientsContext;
        internal static IHostEnvironment _hostEnvironment;
        public static ISteamWebClientConfigBuilder RegisterSteamWebClients(this IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;

            _httpClientsContext = configuration.GetSection(nameof(HttpClientsContextConfig)).Get<HttpClientsContextConfig>();
            services.AddSingleton(_httpClientsContext);


            return new SteamWebClientConfigBuilder(services);
        }

        public static IServiceCollection RegisterStoreService(this IServiceCollection service)
        {
            service.AddScoped<ISteamStoreApiWebClient, StoreApiClient>();

            return service;
        }

        internal static ISteamWebClientConfigBuilder AddHttpClient<THttpClient, THttpClientConfig>(this ISteamWebClientConfigBuilder configBuilder, HttpClientConfigFactory<THttpClientConfig> httpClientConfigFactory = null)
            where THttpClient : class
            where THttpClientConfig : HttpClientConfig
        {
            var httpClientContextType = _httpClientsContext.GetType();
            var props = httpClientContextType.GetProperties();
            var configProp = props.FirstOrDefault(x => x.PropertyType == typeof(THttpClientConfig));

            var httpClientConfig = (THttpClientConfig)configProp.GetValue(_httpClientsContext)
                ?? httpClientConfigFactory?.Create(_hostEnvironment)
                ?? throw new ArgumentNullException($"Erro ao criar client {typeof(THttpClientConfig).Name}");

            configBuilder.Services.RegisterSteam<THttpClient>(httpClientConfig);
            return configBuilder;
        }

        private static void RegisterSteam<THttpClient>(this IServiceCollection services, HttpClientConfig httpClientConfig)
            where THttpClient : class
        {
            services.AddHttpClient<THttpClient>(
                typeof(THttpClient).Name,
                client => client.BaseAddress = new Uri(httpClientConfig.BaseAddress))
                .AddTypedClient(clientConfig => RestService.For<THttpClient>(clientConfig));
        }
    }
}
