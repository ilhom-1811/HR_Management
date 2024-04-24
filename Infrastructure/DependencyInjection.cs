using Application.Common;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationDbInitializer, ApplicationDbInitializer>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<IBaseService<Department>, DepartmentService>();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (configuration["UseInMemoryDatabase"] == "true")
                options.UseInMemoryDatabase("testDb");
            else
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));
        });

        return services;
    }
}