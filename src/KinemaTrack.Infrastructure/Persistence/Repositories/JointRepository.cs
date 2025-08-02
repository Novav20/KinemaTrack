using System;
using KinemaTrack.Application.Common.Interfaces;
using KinemaTrack.Domain.Entities;
using KinemaTrack.Infrastructure.Data;

namespace KinemaTrack.Infrastructure.Persistence.Repositories;

public class JointRepository(ApplicationDbContext context) : IJointRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task AddAsync(Joint joint)
    {
        await _context.Joints.AddAsync(joint);
        await _context.SaveChangesAsync();
    }
}
