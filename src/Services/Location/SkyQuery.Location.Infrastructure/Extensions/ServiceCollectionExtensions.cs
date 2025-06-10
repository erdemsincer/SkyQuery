using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkyQuery.Location.Application.Common.Interfaces;
using SkyQuery.Location.Infrastructure.Persistence;

namespace SkyQuery.Location.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LocationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("LocationDb")));

        services.AddScoped<ILocationDbContext>(provider => provider.GetRequiredService<LocationDbContext>());

        return services;
    }
}
