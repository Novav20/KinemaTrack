using System;
using KinemaTrack.Application.Common.Interfaces;
using KinemaTrack.Infrastructure.Data;
using KinemaTrack.Infrastructure.Persistence.Repositories;
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

        services.AddScoped<IRobotArmRepository, RobotArmRepository>();

        return services;
    }
}
