using KinemaTrack.Application.Common.Interfaces;
using KinemaTrack.Domain.Entities;
using KinemaTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KinemaTrack.Infrastructure.Persistence.Repositories;

public class JointRepository(ApplicationDbContext context) : IJointRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task AddAsync(Joint joint)
    {
        await _context.Joints.AddAsync(joint);
        await _context.SaveChangesAsync();
    }

    public async Task<Joint?> GetByIdAsync(Guid id)
    {
        return await _context.Joints.FirstOrDefaultAsync(j => j.Id == id);
    }

    public async Task UpdateAsync(Joint joint)
    {
        // Tell the context that the provided joint is in a Modified state
        _context.Entry(joint).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }
}
