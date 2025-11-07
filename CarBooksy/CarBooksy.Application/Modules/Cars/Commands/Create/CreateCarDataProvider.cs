using CarBooksy.Domain.Entities;
using CarBooksy.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CarBooksy.Application.Modules.Cars.Commands.Create;
internal interface ICreateCarDataProvider
{
    ValueTask<EntityEntry<Car>> AddCarAsync(Car car, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
internal class CreateCarDataProvider(ApplicationDbContext context) : ICreateCarDataProvider
{
    // The method can be sync since AddAsync in ef core is not truly async
    // It is only async when using value generators that require database access
    // like sequences in oracle or sql server
    // In other cases it is just a wrapper around the sync method
    public ValueTask<EntityEntry<Car>> AddCarAsync(Car car, CancellationToken cancellationToken) 
        => context.Cars.AddAsync(car, cancellationToken);
    
    // TODO: Implement Unit of Work pattern to avoid calling SaveChangesAsync multiple times in a single request
    // For now it is ok since we are only creating a single entity
    // It will keep approach of 'One transactional requests'
    public Task SaveChangesAsync(CancellationToken cancellationToken) 
        => context.SaveChangesAsync(cancellationToken);
}