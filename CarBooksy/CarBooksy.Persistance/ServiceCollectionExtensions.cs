using Microsoft.Extensions.DependencyInjection;

namespace CarBooksy.Persistance;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();

        return services;
    }
}