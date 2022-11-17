namespace Steam.Api.Configuration.Clients
{
    public abstract class HttpClientConfig
    {
        public string BaseAddress { get; set; }

        public HttpClientConfig(string baseAddress)
        {
            BaseAddress = baseAddress;
        }

        public HttpClientConfig()
        {
        }
    }
}
