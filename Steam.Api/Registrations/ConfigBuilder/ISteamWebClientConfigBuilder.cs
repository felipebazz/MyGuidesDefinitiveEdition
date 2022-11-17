using Microsoft.Extensions.DependencyInjection;

namespace Steam.Api.Registrations.ConfigBuilder
{
    public interface ISteamWebClientConfigBuilder
    {
        IServiceCollection Services { get; }
    }
}
