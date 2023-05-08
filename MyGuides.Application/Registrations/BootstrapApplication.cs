using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyGuides.Application.Profiles;
using MyGuides.Application.UseCases.Achievements.GetAchievements;
using MyGuides.Application.UseCases.BannerTypes.GetBannerTypes;
using MyGuides.Application.UseCases.Games.AddGame;
using MyGuides.Application.UseCases.Games.GetGames;
using MyGuides.Application.UseCases.Games.UpdateImages;
using MyGuides.Application.UseCases.Sections.GetSections;
using MyGuides.Application.UseCases.Users.AddUser;
using MyGuides.Application.UseCases.Users.GetUsers;
using MyGuides.Domain.Profiles;
using Steam.Api.Clients.StoreApi;
using Steam.Api.Clients.WebApi;
using Steam.Api.Registrations;

namespace MyGuides.Application.Registrations
{
    public static class BootstrapApplication
    {
        public static IServiceCollection RegistarApplication(this IServiceCollection service, IConfiguration configuration, IHostEnvironment environment)
        {
            AddAutoMapper(service);
            AddSteamApi(service, configuration, environment);

            service.AddScoped<IGetBannerTypesUseCase, GetBannerTypesUseCase>();
            service.AddScoped<IAddGameFromSteamStoreUseCase, AddGameFromSteamStoreUseCase>();
            service.AddScoped<IGetGamesUseCase, GetGamesUseCase>();
            service.AddScoped<IGetAchievementsUseCase, GetAchievementsUseCase>();
            service.AddScoped<IUpdateGameImagesUseCase, UpdateGameImagesUseCase>();
            service.AddScoped<IGetSectionsUseCase, GetSectionsUseCase>();
            service.AddScoped<IAddUserUseCase,AddUserUseCase>();
            service.AddScoped<IGetUsersUseCase,GetUsersUseCase>();
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

        public static void AddSteamApi(this IServiceCollection service, IConfiguration configuration, IHostEnvironment environment)
        {
            service.RegisterSteamWebClients(configuration, environment)
                .AddSteamWebApiClient()
                .AddStoreApiWebClient();

            service.RegisterStoreService();
        }
    }
}
