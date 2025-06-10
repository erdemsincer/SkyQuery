using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkyQuery.Auth.Application.Auth.Interfaces;
using SkyQuery.Auth.Application.Common.Interfaces;
using SkyQuery.Auth.Infrastructure.Identity;
using SkyQuery.Auth.Infrastructure.Persistence;

namespace SkyQuery.Auth.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AuthDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("AuthDb")));

        services.AddScoped<IAuthDbContext>(provider => provider.GetRequiredService<AuthDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
