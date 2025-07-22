using KinemaTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KinemaTrack.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
{
    public DbSet<RobotArm> RobotArms { get; set; }
}
