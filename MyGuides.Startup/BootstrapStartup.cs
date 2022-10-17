using Microsoft.AspNetCore.Builder;
using MyGuides.Application.Registrations;
using MyGuides.Domain.Registrations;
using MyGuides.Infra.Data.Registrations;
using MyGuides.Notifications.Registrations;


namespace MyGuides.Startup
{
    public static class BootstrapStartup
    {
        public static void RegisterStartup(this WebApplicationBuilder builder)
        {
            AddBootstrapMyGuides(builder);
        }

        public static void AddBootstrapMyGuides(WebApplicationBuilder builder)
        {
            builder.Services.RegistarDomain();
            builder.Services.RegisterData(builder.Configuration);
            builder.Services.RegisterNotifications();
            builder.Services.RegistarApplication();
        }
    }
}