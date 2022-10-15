using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGuides.Infra.Data.Contexts.Database;

namespace MyGuides.Infra.Data
{
    public static class BootstrapData
    {
        public static IServiceCollection RegisterData(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<MyGuidesContext>();

            return service;
        }
    }
}
