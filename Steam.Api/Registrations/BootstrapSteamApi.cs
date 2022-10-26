using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Steam.Api.Constants;
using Steam.Api.Interfaces;

namespace Steam.Api.Registrations
{
    public static class BootstrapSteamApi
    {
        public static IServiceCollection RegisterSteamApi(this IServiceCollection service, IConfiguration  configuration)
        {
            var baseAddres = configuration[SteamApiConstants.SteamApibaseAddres].ToString();
            //var apiKey = configuration[SteamApiConfiguration.apiKey].ToString();

            service.AddRefitClient<ISteamUserStats>()
                .ConfigureHttpClient(config =>
                {
                    config.BaseAddress = new Uri(baseAddres);
                });

            return service;
        }
    }
}
