namespace KinemaTrack.Application.Features.RobotArms.Commands;

public class AddJointCommand
{
    /// <summary>
    /// Command to add a joint to a robot arm
    /// </summary>
    public Guid RobotArmId { get; set; }

    /// <summary>
    /// Angle of the joint in degrees
    /// </summary>
    public double Angle { get; set; }
    public double LinkLength { get; set; }
}
