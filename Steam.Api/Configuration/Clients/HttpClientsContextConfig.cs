using Steam.Api.Clients.StoreApi.Configurations;
using Steam.Api.Clients.WebApi.Configurations;

namespace Steam.Api.Configuration.Clients
{
    public class HttpClientsContextConfig
    {
        public SteamWebApiClientConfig SteamWebApiClientConfig { get; set; }

        public StoreApiClientConfig StoreApiClientConfig { get; set; }
    }
}
