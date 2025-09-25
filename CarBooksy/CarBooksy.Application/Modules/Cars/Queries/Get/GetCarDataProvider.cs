using CarBooksy.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarBooksy.Application.Modules.Cars.Queries.Get;

public interface IGetCarDataProvider
{
    Task<GetCarByIdQueryResponse?> Get(Guid id, CancellationToken cancellationToken);
}
public class GetCarDataProvider(ApplicationDbContext context) : IGetCarDataProvider
{
    public async Task<GetCarByIdQueryResponse?> Get(Guid id, CancellationToken cancellationToken) => 
        await context.Cars
            .Where(c => c.Id == id && c.IsDeleted == false)
            .Select(c => new GetCarByIdQueryResponse
            {
                Make = c.Make,
                Model = c.Model,
                BodyType = c.BodyType,
                PlateNumber = c.PlateNumber,
                ProductionYear = c.ProductionYear,
                VinCode = c.VinCode,
                Status = c.Status
            })
            .FirstOrDefaultAsync(cancellationToken);
}