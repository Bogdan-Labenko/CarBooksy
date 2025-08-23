using CarBooksy.Domain.Entities;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands;

public record CreateCarCommand(string make, string model, int year, string vin, string plate, BodyType bodyType, CarStatus status)
    : IRequest<Guid>;

public class CreateCarHandler(ICreateCarDbProvider provider) : IRequestHandler<CreateCarCommand, Guid>
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