using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyGuides.Application.Profiles;
using MyGuides.Application.UseCases.BannerTypes.GetBannerTypes;
using MyGuides.Application.UseCases.Games.AddGame;
using MyGuides.Application.UseCases.Games.GetGames;
using MyGuides.Domain.Entities.Profiles;

namespace MyGuides.Application.Registrations
{
    public static class BootstrapApplication
    {
        public static IServiceCollection RegistarApplication(this IServiceCollection service)
        {
            AddAutoMapper(service);

            service.AddScoped<IGetBannerTypesUseCase, GetBannerTypesUseCase>();
            service.AddScoped<IAddGameFromSteamStoreUseCase, AddGameFromSteamStoreUseCase>();
            service.AddScoped<IGetGamesUseCase, GetGamesUseCase>();

            return service;
        }

        private static void AddAutoMapper(this IServiceCollection service)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationMapperProfile());
                mc.AddProfile(new DomainMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
        }
    }
}
