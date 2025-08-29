namespace KinemaTrack.Application.Features.RobotArms.Commands;

public class UpdateJointAngleCommand
{
    public Guid JointId { get; set; }
    public double NewAngleInDegrees { get; set; }
}
