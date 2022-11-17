using Microsoft.Extensions.DependencyInjection;

namespace Steam.Api.Registrations.ConfigBuilder
{
    public class SteamWebClientConfigBuilder : ISteamWebClientConfigBuilder
    {
        public IServiceCollection Services {get; private set;}

        public SteamWebClientConfigBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
