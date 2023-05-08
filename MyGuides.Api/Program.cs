using MyGuides.Startup;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"Enviroment: {builder.Environment.EnvironmentName}");

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.RegisterStartup(builder.Environment);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Development",
        policy =>
        {
            policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });

    options.AddPolicy(name: "Production",
        policy =>
        {
            policy
            .WithMethods("GET", "POST", "PUT", "DELETE")
            .WithOrigins("https://localhost:7108")
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader();
        });
});

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "My Guides Definitive Edition",
            Version = "v1",
            Description = "API REST para a criação de guias na STEAM",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "legendary god speed",
                Url = new Uri("https://github.com/legendarygodspeed/MyGuidesDefinitiveEdition/")
            }
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Tests"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
