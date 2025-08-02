using System;
using KinemaTrack.Domain.Entities;

namespace KinemaTrack.Application.Common.Interfaces;

public interface IRobotArmRepository
{
    Task<IEnumerable<RobotArm>> GetAllAsync();
    Task AddAsync(RobotArm robotArm);
    Task<RobotArm?> GetByIdAsync(Guid id);
}
