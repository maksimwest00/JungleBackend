using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JungleBackend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ApplicationDbContext>(_ => new ApplicationDbContext(
            configuration.GetConnectionString("JungleServiceDb")!));
        // services.AddScoped<ILocationRepository, LocationRepository>();
        return services;
    }
}