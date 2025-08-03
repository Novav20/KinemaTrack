using KinemaTrack.Domain.Entities;

namespace KinemaTrack.Application.Features.RobotArms.Queries;

public class RobotArmDto
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; } 
    public ICollection<Joint> Joints { get; init; } // TODO: replace with dto
}
