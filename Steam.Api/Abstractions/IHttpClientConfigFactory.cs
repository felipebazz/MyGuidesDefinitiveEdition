using Microsoft.Extensions.Hosting;
using Steam.Api.Configuration.Clients;

namespace Steam.Api.Abstractions
{
    public interface IHttpClientConfigFactory<THttpClientFactory>
        where THttpClientFactory : HttpClientConfig
    {
        THttpClientFactory Create(IHostEnvironment hostEnviroment);
    }
}
