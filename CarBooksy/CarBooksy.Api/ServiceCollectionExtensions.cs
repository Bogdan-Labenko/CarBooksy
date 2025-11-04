using CarBooksy.Domain.Entities;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace CarBooksy.Api;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddControllers().AddOData(opt =>
            opt.Select().Filter().OrderBy().Count().Expand());

        return services;
    }
}