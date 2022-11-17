using Steam.Api.Abstractions;

namespace Steam.Api.Clients.StoreApi.Configurations
{
    public class StoreApiClientConfigFactory : HttpClientConfigFactory<StoreApiClientConfig>
    {
        protected override StoreApiClientConfig CreateConfiguration()
        {
            return new StoreApiClientConfig("https://store.steampowered.com/api/");
        }
    }
}
