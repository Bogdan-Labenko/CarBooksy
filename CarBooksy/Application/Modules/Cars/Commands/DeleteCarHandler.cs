using CarBooksy.Domain.Entities;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands;

public record DeleteCarCommand(Guid Id) : IRequest<bool>;

public class DeleteCarHandler(IDeleteCarDbProvider provider) : IRequestHandler<DeleteCarCommand, bool>
{
    public async Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        return await provider.Delete(request.Id, cancellationToken);
    }
}