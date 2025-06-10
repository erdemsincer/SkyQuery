using Microsoft.EntityFrameworkCore;
using SkyQuery.GeoData.Application.Common.Interfaces;
using SkyQuery.GeoData.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SkyQuery.GeoData.Infrastructure.Persistence;

public class GeoDataDbContext : DbContext, IGeoDataDbContext
{
    public GeoDataDbContext(DbContextOptions<GeoDataDbContext> options) : base(options) { }
    public DbSet<Domain.Entities.GeoData> GeoDatas => Set<Domain.Entities.GeoData>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Domain.Entities.GeoData>().ToTable("GeoDatas");
    }
}
