using Microsoft.EntityFrameworkCore;
using SkyQuery.Auth.Domain.Entities;
using SkyQuery.Auth.Application.Auth.Interfaces;
using SkyQuery.Auth.Application.Common.Interfaces;

namespace SkyQuery.Auth.Infrastructure.Persistence;

public class AuthDbContext : DbContext, IAuthDbContext
{
    public DbSet<User> Users => Set<User>();

    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
    }
}
