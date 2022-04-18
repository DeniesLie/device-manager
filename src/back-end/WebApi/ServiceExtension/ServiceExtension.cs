using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Domain;
using Domain.Entities;
using Application;

namespace WebApi.ServiceExtension;

public static class ServiceExtension
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
    {
        string connectionString;
        if (env.IsDevelopment())
            connectionString = config.GetConnectionString("DevDockerConnection");
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
        services.AddScoped<IRepository<ProjectMembership>, Repository<ProjectMembership>>();
    }

    public static void AddMapper(this IServiceCollection services)
    {
        var mapConfig = new MapperConfiguration(config =>
        {
            config.AddProfile(new Application.MapperProfiles.DeviceProfile());
            config.AddProfile(new Application.MapperProfiles.OSProfile());
            config.AddProfile(new Application.MapperProfiles.ProjectMembershipProfile());
            config.AddProfile(new Application.MapperProfiles.ProjectProfile());
            config.AddProfile(new Application.MapperProfiles.UserProfile());
        });
        IMapper mapper = mapConfig.CreateMapper();
        services.AddSingleton<IMapper>(mapper);
    }
}