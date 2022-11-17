using Steam.Api.Configuration.Clients;

namespace Steam.Api.Clients.WebApi.Configurations
{
    public class SteamWebApiClientConfig : HttpClientConfig
    {
        public SteamWebApiClientConfig(string baseAddress)
            : base(baseAddress)
        {
        }

        public SteamWebApiClientConfig()
        {
        }
    }
}
