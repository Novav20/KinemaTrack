
namespace KinemaTrack.Application.Features.RobotArms.Queries;

public class JointDto
{
    public Guid Id { get; init; }
    public int JointNumber { get; set; }
    public double AngleInRadians { get; set; } // For calculations
    public double AngleInDegrees { get; set; } // For display
    public double LinkLength { get; set; }
}