using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyGuides.Application.Registrations;
using MyGuides.Domain.Registrations;
using MyGuides.Infra.Data.Registrations;
using MyGuides.Notifications.Registrations;
using Steam.Api.Registrations;

namespace MyGuides.Startup
{
    public static class BootstrapStartup
    {
        public static void RegisterStartup(this WebApplicationBuilder builder, IWebHostEnvironment hostEnvironment)
        {
            ConfigureCultureInfo(builder);
            AddJsonFile(builder, hostEnvironment);
            AddBootstrapMyGuides(builder, hostEnvironment);
        }

        private static void AddBootstrapMyGuides(WebApplicationBuilder builder, IWebHostEnvironment hostEnvironment)
        {
            builder.Services.RegistarDomain();
            builder.Services.RegisterData(builder.Configuration);
            builder.Services.RegisterNotifications();
            builder.Services.RegistarApplication(builder.Configuration, hostEnvironment);
        }

        private static void AddJsonFile(WebApplicationBuilder builder, IWebHostEnvironment hostEnvironment)
        {
            builder.Configuration.SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true);
            //.AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName.ToLower()}.json", true);
            builder.Configuration.AddEnvironmentVariables();
        }

        private static void ConfigureCultureInfo(WebApplicationBuilder builder)
        {
            builder.Services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    options.DefaultRequestCulture = new RequestCulture("pt-BR");
                });
        }
    }
}