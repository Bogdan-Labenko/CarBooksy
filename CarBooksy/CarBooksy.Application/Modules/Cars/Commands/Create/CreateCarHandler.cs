using CarBooksy.Domain.Entities;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands.Create;

public class CreateCarHandler(ICreateCarDataProvider provider) : IRequestHandler<CreateCarCommand, Guid>
{
    public async Task<Guid> Handle(CreateCarCommand commandBase, CancellationToken cancellationToken)
    {
        var carResult = Car.Create(commandBase);

        if (!carResult.IsSuccess)
        {
            throw new Exception("Car creation failed");
        }

        await provider.AddCarAsync(carResult.Value!, cancellationToken);
        await provider.SaveChangesAsync(cancellationToken);

        return carResult.Value!.Id;
    }
}