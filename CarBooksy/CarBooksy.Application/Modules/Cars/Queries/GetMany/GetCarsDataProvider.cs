using System.Reflection;
using CarBooksy.Domain.Entities;
using CarBooksy.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace CarBooksy.Application.Modules.Cars.Queries.GetMany;

public interface IGetCarsDataProvider
{
    Task<GetCarsResponse> Get(GetCarsQuery query, CancellationToken cancellationToken);
}

public class GetCarsDataProvider(ApplicationDbContext _context) : IGetCarsDataProvider
{
    public async Task<GetCarsResponse> Get(GetCarsQuery carsQuery, CancellationToken cancellationToken)
    {
        var query = _context.Cars.AsQueryable();

        // Get all properties of the request
        var properties = typeof(GetCarsQuery).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var filters = new List<string>();
        var values = new List<object>();
        int paramIndex = 0;

        foreach (var prop in properties)
        {
            // Skip system fields Offset and Limit
            if (prop.Name == "Offset" || prop.Name == "Limit")
                continue;

            var value = prop.GetValue(carsQuery);
            if (value != null)
            {
                filters.Add($"{prop.Name} == @{paramIndex}");
                values.Add(value);
                paramIndex++;
            }
        }

        if (filters.Any())
        {
            var whereClause = string.Join(" AND ", filters);
            query = query.Where(whereClause, values.ToArray());
        }

        var total = await query.CountAsync(cancellationToken);

        var cars = await query
            .Skip(carsQuery.Offset)
            .Take(carsQuery.Limit)
            .ToListAsync(cancellationToken);

        return new GetCarsResponse
        {
            Cars = cars,
            Total = total,
            Offset = carsQuery.Offset,
            Limit = carsQuery.Limit
        };
    }
}