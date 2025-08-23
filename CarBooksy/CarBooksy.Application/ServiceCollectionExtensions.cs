using CarBooksy.Application.Modules.Cars.Commands.Create;
using CarBooksy.Application.Modules.Cars.Queries.Get;
using CarBooksy.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace CarBooksy.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GetCarByIdHandler).Assembly);
        });
        
        services.Scan(scan => scan
            .FromAssemblies(typeof(ICreateCarDbProvider).Assembly)
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("DbProvider")))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );

        return services;
    }
}