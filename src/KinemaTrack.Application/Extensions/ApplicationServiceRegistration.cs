using System;
using KinemaTrack.Application.Features.RobotArms;
using Microsoft.Extensions.DependencyInjection;

namespace KinemaTrack.Application.Extensions;


public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRobotArmService, RobotArmService>();

        return services;
    }
}
