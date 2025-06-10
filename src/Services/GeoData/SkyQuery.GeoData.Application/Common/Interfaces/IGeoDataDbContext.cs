using Microsoft.EntityFrameworkCore;
using SkyQuery.GeoData.Domain.Entities;
using System.Collections.Generic;

namespace SkyQuery.GeoData.Application.Common.Interfaces;

public interface IGeoDataDbContext
{
    DbSet<Domain.Entities.GeoData> GeoDatas { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
