namespace KinemaTrack.Application.Features.RobotArms.Commands;

public class CreateRobotArmCommand
{
    // TODO: I want to use fluent validation instead (future feature)
    public required string Name { get; set; }
    public string? Description { get; set; }
}
