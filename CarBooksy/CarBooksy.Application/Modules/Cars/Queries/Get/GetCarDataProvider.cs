using CarBooksy.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarBooksy.Application.Modules.Cars.Queries.Get;

public interface IGetCarDataProvider
{
    Task<CarDto?> Get(Guid id, CancellationToken cancellationToken);
}
public class GetCarDataProvider(ApplicationDbContext context) : IGetCarDataProvider
{
    public async Task<CarDto?> Get(Guid id, CancellationToken cancellationToken)
    {
        var a =  await context.Cars
            .Where(c => c.Id == id && c.IsDeleted == false)
            .Select(c => new CarDto
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
        return a;
    }
}