using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyGuides.Domain.Entities.Profiles;
using System.Reflection;

namespace MyGuides.Domain.Registrations
{
    public static class BootstrapDomain
    {
        public static IServiceCollection RegistarDomain(this IServiceCollection service)
        {
            //AddAutoMapper(service);

            service.AddMediatR(Assembly.GetExecutingAssembly());

            return service;
        }

    }
}
