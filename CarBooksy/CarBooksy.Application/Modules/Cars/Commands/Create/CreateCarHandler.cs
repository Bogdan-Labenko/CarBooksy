using CarBooksy.Domain.Entities;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands.Create;

public class CreateCarHandler(ICreateCarDataProvider provider) : IRequestHandler<CreateCarCommand, Guid>
{
    public async Task<Guid> Handle(CreateCarCommand commandBase, CancellationToken cancellationToken)
    {
        var car = Car.Create(commandBase);

        await provider.AddCarAsync(car, cancellationToken);
        await provider.SaveChangesAsync(cancellationToken);

        return car.Id;
    }
}