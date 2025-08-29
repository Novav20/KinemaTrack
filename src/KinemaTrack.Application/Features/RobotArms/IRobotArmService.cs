using KinemaTrack.Application.Features.RobotArms.Commands;
using KinemaTrack.Application.Features.RobotArms.Queries;

namespace KinemaTrack.Application.Features.RobotArms;

public interface IRobotArmService
{
    Task<IEnumerable<RobotArmDto>> GetAllArmsForDisplayAsync();
    Task CreateNewArmAsync(CreateRobotArmCommand command);

    Task AddJointAsync(AddJointCommand command);

    Task<RobotArmDto> GetRobotArmDetailsAsync(Guid id);

    Task UpdateJointAngleAsync(UpdateJointAngleCommand command);
}
