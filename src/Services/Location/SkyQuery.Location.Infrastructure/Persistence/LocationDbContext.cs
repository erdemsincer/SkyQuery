using Microsoft.EntityFrameworkCore;
using SkyQuery.Location.Application.Common.Interfaces;
using SkyQuery.Location.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SkyQuery.Location.Infrastructure.Persistence;

public class LocationDbContext : DbContext, ILocationDbContext
{
    public LocationDbContext(DbContextOptions<LocationDbContext> options) : base(options) { }
    public DbSet<Domain.Entities.Location> Locations => Set<Domain.Entities.Location>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Domain.Entities.Location>().ToTable("Locations");
    }
}
