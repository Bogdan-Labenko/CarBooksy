using CarBooksy.Domain;
using CarBooksy.Persistance;

namespace CarBooksy.Application.Modules.Cars.Commands.Update;

public interface IUpdateCarDataProvider
{
    public Task<Result<Guid?>> Update(Guid id, CarDto carDto, CancellationToken cancellationToken);
}

public class UpdateCarDataProvider(ApplicationDbContext context) : IUpdateCarDataProvider
{
    public async Task<Result<Guid?>> Update(Guid id, CarDto carDto, CancellationToken cancellationToken)
    {
        var car = await context.Cars.FindAsync(id);
        if (car is null)
        {
            return null;
        }

        car.Make = carDto.Make;
        car.Model = carDto.Model;
        car.ProductionYear = carDto.ProductionYear;
        car.PlateNumber = carDto.PlateNumber;
        car.VinCode = carDto.VinCode;
        car.Status = carDto.Status;
        car.BodyType = carDto.BodyType;

        await context.SaveChangesAsync(cancellationToken);
        return new Result<Guid?>(id, true, null);
    }
}