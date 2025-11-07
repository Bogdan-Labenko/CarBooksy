using CarBooksy.Shared.Models.Cars;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands.Update;

public class UpdateCarCommand : UpdateCarCommandBase, IRequest;

internal class UpdateCarHandler(IUpdateCarDataProvider provider) : IRequestHandler<UpdateCarCommand>
{
    public async Task Handle(UpdateCarCommand command, CancellationToken cancellationToken)
    {
        await provider.Update(command, cancellationToken);
    }
}