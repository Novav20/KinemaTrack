using System;
using KinemaTrack.Domain.Entities;

namespace KinemaTrack.Application.Common.Interfaces;

public interface IJointRepository
{
    Task AddAsync(Joint joint);
}
