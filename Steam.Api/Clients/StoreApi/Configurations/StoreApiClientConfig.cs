using Steam.Api.Configuration.Clients;

namespace Steam.Api.Clients.StoreApi.Configurations
{
    public class StoreApiClientConfig : HttpClientConfig
    {
        public StoreApiClientConfig(string baseAddress)
            : base(baseAddress)
        {
        }

        public StoreApiClientConfig()
        {
        }
    }
}
