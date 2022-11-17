using Steam.Api.Abstractions;

namespace Steam.Api.Clients.WebApi.Configurations
{
    public class SteamWebApiClientConfigFactory : HttpClientConfigFactory<SteamWebApiClientConfig>
    {
        protected override SteamWebApiClientConfig CreateConfiguration()
        {
            return new SteamWebApiClientConfig("https://api.steampowered.com/");
        }
    }
}
