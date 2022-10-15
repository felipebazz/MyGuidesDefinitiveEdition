using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyGuides.Notifications.Context;
using MyGuides.Notifications.Filters;
using System.Diagnostics.CodeAnalysis;

namespace MyGuides.Notifications.Registrations
{
    [ExcludeFromCodeCoverage]
    public static class BootstrapNotification
    {
        public static void UseNotifications(this IServiceCollection services)
        {
            services.AddMvcCore(s =>
            {
                s.EnableEndpointRouting = false;
                s.Filters.Add<NotificationFilter>();
                s.Filters.Add<ExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddScoped<INotificationContext, NotificationContext>();
        }
    }
}
