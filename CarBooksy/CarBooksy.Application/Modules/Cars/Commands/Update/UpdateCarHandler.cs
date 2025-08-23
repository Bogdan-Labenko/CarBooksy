using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands.Update;

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