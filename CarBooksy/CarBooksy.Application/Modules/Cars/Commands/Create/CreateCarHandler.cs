using CarBooksy.Domain.Entities;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands.Create;

public class CreateCarHandler(ICreateCarDataProvider provider) : IRequestHandler<CreateCarCommand, Guid>
{
    public Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var carResult = Car.Create(
            request.make,
            request.model,
            request.year,
            request.vin,
            request.plate,
            request.bodyType,
            request.status
        );

        if (!carResult.IsSuccess)
        {
            return null;
        }

        return provider.Create(carResult.Value, cancellationToken);
    }
}