using SkyQuery.Auth.Domain.Entities;

namespace SkyQuery.Auth.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
