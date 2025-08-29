using KinemaTrack.Application.Common.Interfaces;
using KinemaTrack.Application.Features.RobotArms.Commands;
using KinemaTrack.Application.Features.RobotArms.Queries;
using KinemaTrack.Domain.Entities;

namespace KinemaTrack.Application.Features.RobotArms;

public class RobotArmService(IRobotArmRepository robotArmRepository, IJointRepository jointRepository) : IRobotArmService
{
    private readonly IRobotArmRepository _robotArmRepository = robotArmRepository;
    private readonly IJointRepository _jointRepository = jointRepository;

    public async Task AddJointAsync(AddJointCommand command)
    {
        var robotArm = await _robotArmRepository.GetByIdAsync(command.RobotArmId, includeJoints: true) ?? throw new ArgumentException($"Robot arm with id {command.RobotArmId} not found.");

        var newJoint = new Joint
        {
            RobotArmId = robotArm.Id,
            LinkLength = command.LinkLength,
            Angle = command.Angle * (Math.PI / 180),
            JointNumber = robotArm.Joints.Count + 1
        };

        await _jointRepository.AddAsync(newJoint);
    }

    public Task CreateNewArmAsync(CreateRobotArmCommand command)
    {
        var newRobotArm = new RobotArm
        {
            Name = command.Name,
            Description = command.Description,
        };

        return _robotArmRepository.AddAsync(newRobotArm);
    }

    public async Task<IEnumerable<RobotArmDto>> GetAllArmsForDisplayAsync()
    {
        var robotArms = await _robotArmRepository.GetAllAsync();
        return robotArms.Select(r => new RobotArmDto
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description,
            CreatedAt = r.CreatedAt,
            UpdatedAt = r.UpdatedAt
        });
    }

    public async Task<RobotArmDto> GetRobotArmDetailsAsync(Guid id)
    {
        var robotArm = await _robotArmRepository.GetByIdAsync(id, includeJoints: true) ?? throw new ArgumentException($"Robot arm with id {id} not found.");
        var robotArmDto = new RobotArmDto
        {
            Id = robotArm.Id,
            Name = robotArm.Name,
            Description = robotArm.Description,
            CreatedAt = robotArm.CreatedAt,
            UpdatedAt = robotArm.UpdatedAt,
            Joints = [.. robotArm.Joints.Select(j => new JointDto
            {
                Id = j.Id,
                JointNumber = j.JointNumber,
                AngleInRadians = j.Angle,
                AngleInDegrees = Math.Round(j.Angle *(180/Math.PI), 2), //TODO: Make it a calculated property in the JointDto Entity
                LinkLength = j.LinkLength
            })]
        };
        // TODO: AutoMapper deferred

        return robotArmDto;
    }

    public async Task UpdateJointAngleAsync(UpdateJointAngleCommand command)
    {
        // 1. Get the joint entity from the database
        var joint = await _jointRepository.GetByIdAsync(command.JointId) ?? throw new ArgumentException($"Joint with id {command.JointId} not found.");

        // 2. Update angle in radians
        joint.Angle = command.NewAngleInDegrees * (Math.PI / 180);

        // 3. Delegate persistence action to the repository
        await _jointRepository.UpdateAsync(joint);
    }
}
