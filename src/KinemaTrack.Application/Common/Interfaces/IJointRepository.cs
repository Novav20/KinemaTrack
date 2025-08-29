using KinemaTrack.Domain.Entities;

namespace KinemaTrack.Application.Common.Interfaces;

public interface IJointRepository
{
    Task AddAsync(Joint joint);
    Task<Joint?> GetByIdAsync(Guid id);
    Task UpdateAsync(Joint joint);
}
