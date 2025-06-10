using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SkyQuery.Auth.Application.Auth.Commands;

namespace SkyQuery.Auth.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly));
            services.AddValidatorsFromAssembly(typeof(RegisterUserCommand).Assembly);
            return services;
        }
    }

}
