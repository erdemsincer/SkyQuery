using SkyQuery.Auth.Domain.Entities;

namespace SkyQuery.Auth.Application.Auth.Interfaces;

public interface IUserRepository
{
    Task<bool> ExistsByEmailAsync(string email);
    Task AddAsync(User user);
}
