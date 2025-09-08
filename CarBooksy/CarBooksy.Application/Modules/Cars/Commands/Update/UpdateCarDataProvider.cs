using CarBooksy.Domain;
using CarBooksy.Persistance;
using CarBooksy.Shared.Models.Cars;

namespace CarBooksy.Application.Modules.Cars.Commands.Update;

public interface IUpdateCarDataProvider
{
    public Task Update(UpdateCarCommandBase commandBase, CancellationToken cancellationToken);
}

public class UpdateCarDataProvider(ApplicationDbContext context) : IUpdateCarDataProvider
{
    public async Task Update(UpdateCarCommandBase commandBase, CancellationToken cancellationToken)
    {
        var car = await context.Cars.FindAsync(commandBase.Id);
        if (car is null)
        {
            throw new Exception("Car not found");
        }
        
        car.Update(commandBase);

        await context.SaveChangesAsync(cancellationToken);
    }
}