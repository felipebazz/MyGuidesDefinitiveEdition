using Microsoft.Extensions.DependencyInjection;
using MyGuides.Application.UseCases;

namespace MyGuides.Application.Registrations
{
    public static class BootstrapApplication
    {
        public static IServiceCollection RegistarApplication(this IServiceCollection service)
        {
            service.AddScoped<IGetBannerTypesUseCase, GetBannerTypesUseCase>();

            return service;
        }
    }
}
