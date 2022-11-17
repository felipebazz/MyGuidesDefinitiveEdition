using Microsoft.Extensions.Hosting;
using Steam.Api.Configuration.Clients;

namespace Steam.Api.Abstractions
{
    public abstract class HttpClientConfigFactory<THttpClientConfig> : IHttpClientConfigFactory<THttpClientConfig>
        where THttpClientConfig : HttpClientConfig
    {
        public THttpClientConfig Create(IHostEnvironment hostEnviroment)
        {
            return CreateConfiguration();
        }

        protected abstract THttpClientConfig CreateConfiguration();
    }
}
