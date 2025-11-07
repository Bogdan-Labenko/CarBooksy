using CarBooksy.Persistance;

namespace CarBooksy.Application.Modules.Cars.Commands.Delete;

internal interface IDeleteCarDataProvider
{
    public Task Delete(Guid id, CancellationToken cancellationToken);
}

internal class DeleteCarDataProvider(ApplicationDbContext context) : IDeleteCarDataProvider
{
    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var car = await context.Cars.FindAsync(id);
        if (car is null)
        {
            throw new KeyNotFoundException($"Car with id {id} not found");
        }
        
        car.Delete();
        await context.SaveChangesAsync(cancellationToken);
    }
}