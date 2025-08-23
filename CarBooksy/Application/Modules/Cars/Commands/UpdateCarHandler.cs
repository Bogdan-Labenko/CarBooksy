using CarBooksy.Domain.Entities;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands;

public record UpdateCarCommand(Guid Id, CarDto CarDto) : IRequest<Guid?>;

public class UpdateCarHandler(IUpdateCarDbProvider provider) : IRequestHandler<UpdateCarCommand, Guid?>
{
    public async Task<Guid?> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var result = await provider.Update(request.Id, request.CarDto, cancellationToken);

        if (result.IsSuccess)
        {
            return request.Id;
        }

        return null;
    }
}