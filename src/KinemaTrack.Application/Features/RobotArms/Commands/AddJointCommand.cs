using System;

namespace KinemaTrack.Application.Features.RobotArms.Commands;

public class AddJointCommand
{
    public Guid RobotArmId { get; set; }
    public double LinkLength { get; set; }
}
