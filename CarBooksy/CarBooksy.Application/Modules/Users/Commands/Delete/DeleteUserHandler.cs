using MediatR;

namespace CarBooksy.Application.Modules.Users.Commands.Delete;

public record DeleteUserCommand(Guid Id) : IRequest;

internal class DeleteUserHandler(IDeleteUserDataProvider provider) : IRequestHandler<DeleteUserCommand>
{
    public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        => provider.Delete(request.Id);
}