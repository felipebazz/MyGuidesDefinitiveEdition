using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MyGuides.Domain.Registrations
{
    public static class BootstrapDomain
    {
        public static IServiceCollection RegistarDomain(this IServiceCollection service)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());

            return service;
        }
    }
}
