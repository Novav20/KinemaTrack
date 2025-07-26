using System.ComponentModel.DataAnnotations.Schema;

namespace KinemaTrack.Domain.Entities;

/// <summary>
/// A joint in a robot arm. Each joint has a number in the arm (JointNumber), an angle (Angle), and a length (LinkLength).
/// </summary>
public class Joint
{
    /// <summary>
    /// A unique identifier for the joint.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The order of the joint in the arm.
    /// </summary>
    public int JointNumber { get; set; }

    /// <summary>
    /// The angle of the joint, also known as the joint variable.
    /// </summary>
    public double Angle { get; set; }

    /// <summary>
    /// The length of the link that follows this joint.
    /// </summary>
    public double LinkLength { get; set; }

    [ForeignKey(nameof(RobotArm))]
    public Guid RobotArmId { get; set; }

    /// <summary>
    /// The robot arm that this joint is a part of.
    /// </summary>
    public RobotArm RobotArm { get; set; } = null!;
}
