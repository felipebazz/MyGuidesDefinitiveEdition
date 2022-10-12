
using Microsoft.EntityFrameworkCore;
using MyGuides.Infra.Data.Contexts.Database;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"Enviroment: {builder.Environment.EnvironmentName}");

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDbContext<MyGuidesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
