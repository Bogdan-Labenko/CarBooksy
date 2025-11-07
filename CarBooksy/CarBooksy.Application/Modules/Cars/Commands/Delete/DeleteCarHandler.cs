using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands.Delete;

public record DeleteCarCommand(Guid Id) : IRequest;

internal class DeleteCarHandler(IDeleteCarDataProvider provider) : IRequestHandler<DeleteCarCommand>
{
    public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        await provider.Delete(request.Id, cancellationToken);
    }
}