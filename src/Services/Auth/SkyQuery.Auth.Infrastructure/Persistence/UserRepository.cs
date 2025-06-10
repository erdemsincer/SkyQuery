using Microsoft.EntityFrameworkCore;
using SkyQuery.Auth.Application.Auth.Interfaces;
using SkyQuery.Auth.Domain.Entities;

namespace SkyQuery.Auth.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _context;
    public UserRepository(AuthDbContext context) => _context = context;

    public async Task<bool> ExistsByEmailAsync(string email)
        => await _context.Users.AnyAsync(u => u.Email == email);

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
    public async Task<User?> GetByEmailAsync(string email)
    => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

}
