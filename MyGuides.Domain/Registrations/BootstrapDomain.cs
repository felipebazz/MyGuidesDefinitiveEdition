using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection; 
using MyGuides.Domain.Entities.Users.Results;
using System.Reflection;

namespace MyGuides.Domain.Registrations
{
    public static class BootstrapDomain
    {
        public static IServiceCollection RegistarDomain(this IServiceCollection service)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());
            service.AddScoped<UserManager<IdentityUser>>();
            return service;
        }

    }
}
