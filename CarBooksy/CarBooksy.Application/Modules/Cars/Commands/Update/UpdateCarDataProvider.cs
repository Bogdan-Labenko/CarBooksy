using CarBooksy.Domain;
using CarBooksy.Persistance;
using CarBooksy.Shared.Models.Cars;

namespace CarBooksy.Application.Modules.Cars.Commands.Update;

internal interface IUpdateCarDataProvider
{
    Task Update(UpdateCarCommandBase commandBase, CancellationToken cancellationToken);
}

internal class UpdateCarDataProvider(ApplicationDbContext context) : IUpdateCarDataProvider
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