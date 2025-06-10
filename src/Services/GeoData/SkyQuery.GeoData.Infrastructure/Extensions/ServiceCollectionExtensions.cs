using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SkyQuery.GeoData.Application.Common.Interfaces;
using SkyQuery.GeoData.Infrastructure.Persistence;

namespace SkyQuery.GeoData.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GeoDataDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("GeoDataDb")));

        services.AddScoped<IGeoDataDbContext>(provider => provider.GetRequiredService<GeoDataDbContext>());

        return services;
    }
}
