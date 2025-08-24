namespace CarBooksy.Api;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers();

        return services;
    }
}