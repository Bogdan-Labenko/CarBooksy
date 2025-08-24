using CarBooksy.Domain.Entities;
using CarBooksy.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarBooksy.Application.Modules.Cars.Commands.Create;
public interface ICreateCarDbProvider
{
    Task<Guid> Create(Car car, CancellationToken cancellationToken);
}
public class CreateCarDataProvider(ApplicationDbContext context) : ICreateCarDbProvider
{
    public async Task<Guid> Create(Car car, CancellationToken cancellationToken)
    {
        var isExist = await context.Cars.AnyAsync(c => c.Id == car.Id, cancellationToken);

        if (isExist)
        {
            throw new Exception("Car with similar Id is exist");
        }
        
        try
        {
            await context.Cars.AddAsync(car, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return car.Id;
    }
}