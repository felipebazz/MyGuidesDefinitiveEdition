using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyGuides.Application.Registrations;
using MyGuides.Domain.Registrations;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Infra.Data.Registrations;
using MyGuides.Notifications.Registrations;
using System.Text;

namespace MyGuides.Startup
{
    public static class BootstrapStartup
    {
        public static void RegisterStartup(this WebApplicationBuilder builder, IWebHostEnvironment hostEnvironment)
        {
            ConfigureCultureInfo(builder);
            AddJsonFile(builder, hostEnvironment);
            AddBootstrapMyGuides(builder, hostEnvironment);
            AddAuth(builder);
            AddIdentity(builder);
        }

        private static void AddIdentity(WebApplicationBuilder builder)
        {
            builder.Services
                .AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequiredLength = 8;
                })
                .AddEntityFrameworkStores<MyGuidesContext>();
        }

        private static void AddAuth(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
                        )
                    };
                });
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