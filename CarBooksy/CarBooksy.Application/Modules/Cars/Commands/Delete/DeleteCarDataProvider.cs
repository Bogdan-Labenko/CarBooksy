using CarBooksy.Persistance;

namespace CarBooksy.Application.Modules.Cars.Commands.Delete;

public interface IDeleteCarDataProvider
{
    public Task<bool> Delete(Guid id, CancellationToken cancellationToken);
}

public class DeleteCarDataProvider(ApplicationDbContext context) : IDeleteCarDataProvider
{
    public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
    {
        var car = await context.Cars.FindAsync(id);
        if (car is null)
        {
            return false;
        }

        car.IsDeleted = true;
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}