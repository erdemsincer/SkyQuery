using Microsoft.EntityFrameworkCore;
using SkyQuery.Auth.Domain.Entities;

namespace SkyQuery.Auth.Infrastructure.Persistence
{
    public class AuthDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
    }
}
