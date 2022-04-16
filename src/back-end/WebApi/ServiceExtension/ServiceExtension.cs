using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Domain;
using Domain.Entities;

namespace WebApi.ServiceExtension;

public static class ServiceExtension
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
    {
        string connectionString;
        if (env.IsDevelopment())
            connectionString = config.GetConnectionString("DevLocaldbConnection");
        else
            connectionString = config.GetConnectionString("AzureConnection");
        
        services.AddDbContext<AppDbContext>(opts 
                => opts.UseSqlServer(connectionString));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Device>, Repository<Device>>();
        services.AddScoped<IRepository<OS>, Repository<OS>>();
        services.AddScoped<IRepository<Project>, Repository<Project>>();
        services.AddScoped<IRepository<User>, Repository<User>>();
        services.AddScoped<IRepository<UserInProject>, Repository<UserInProject>>();
    }

}