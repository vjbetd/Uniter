using Microsoft.Extensions.DependencyInjection;
using UniterEntity.Repositories;

namespace UniterEntity.Extensions.DependencyInjection;

/// <summary>
/// Static class that adds the entity service collection extension method.
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Adds the entity dependency injection configuration to the <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" />.</param>
    /// <returns>The <see cref="IServiceCollection" />.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Repositories layer
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
