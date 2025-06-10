using Microsoft.EntityFrameworkCore;
using SkyQuery.Location.Domain.Entities;
using System.Collections.Generic;

namespace SkyQuery.Location.Application.Common.Interfaces;

public interface ILocationDbContext
{
    DbSet<Domain.Entities.Location> Locations { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
