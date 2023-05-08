using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGuides.Domain.Entities.Achievements.Repositories;
using MyGuides.Domain.Entities.Banners.Repository;
using MyGuides.Domain.Entities.BannerTypes.Repository;
using MyGuides.Domain.Entities.Difficulties.Repository;
using MyGuides.Domain.Entities.Games.Repository;
using MyGuides.Domain.Entities.Sections.Repository;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Infra.Data.Contexts.Repositories.Achievements;
using MyGuides.Infra.Data.Contexts.Repositories.Banners;
using MyGuides.Infra.Data.Contexts.Repositories.BannerTypes;
using MyGuides.Infra.Data.Contexts.Repositories.Difficulties;
using MyGuides.Infra.Data.Contexts.Repositories.Games;
using MyGuides.Infra.Data.Contexts.Repositories.Sections;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Infra.Data.Registrations
{
    [ExcludeFromCodeCoverage]
    public static class BootstrapData
    {
        public static IServiceCollection RegisterData(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<MyGuidesContext>();
            service.AddScoped<DbContext, MyGuidesContext>();

            RegisterRepositories(service);

            return service;
        }

        private static void RegisterRepositories(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, GameRepository>();
            service.AddScoped<IBannerRepository, BannerRepository>();
            service.AddScoped<ISectionRepository, SectionRepository>();
            service.AddScoped<IDifficultyRepository, DifficultyRepository>();
            service.AddScoped<IBannerTypeRepository, BannerTypeRepository>();
            service.AddScoped<IAchievementRepository, AchievementRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
