using CarBooksy.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarBooksy.Application.Modules.Cars;

public interface IGetCarDbProvider
{
    Task<CarDto?> Get(Guid id, CancellationToken cancellationToken);
}

public class GetCarDbProvider(ApplicationDbContext context) : IGetCarDbProvider
{
    public async Task<CarDto?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await context.Cars
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
    }
}