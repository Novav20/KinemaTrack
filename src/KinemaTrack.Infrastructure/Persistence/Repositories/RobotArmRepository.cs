using System;
using KinemaTrack.Application.Common.Interfaces;
using KinemaTrack.Domain.Entities;
using KinemaTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KinemaTrack.Infrastructure.Persistence.Repositories;

public class RobotArmRepository(ApplicationDbContext context) : IRobotArmRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<IEnumerable<RobotArm>> GetAllAsync()
    {
        var robotArms = await _context.RobotArms.ToListAsync();
        return robotArms;
    }
    public async Task AddAsync(RobotArm robotArm)
    {
        await _context.RobotArms.AddAsync(robotArm);
        await _context.SaveChangesAsync(); // It's common for a simple AddAsync to also save changes.
    }

    public async Task<RobotArm?> GetByIdAsync(Guid id, bool includeJoints = false)
    {
        var query = _context.RobotArms.AsQueryable();

        if (includeJoints)
        {
            query = query.Include(r => r.Joints);
        }

        var robotArm = await query.FirstOrDefaultAsync(r => r.Id == id);
        return robotArm;
    }
}
