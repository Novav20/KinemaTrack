using System;
using KinemaTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KinemaTrack.Infrastructure.Extensions;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseOracle(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("KinemaTrack.Infrastructure"));
        });
        
        return services;
    }
}
