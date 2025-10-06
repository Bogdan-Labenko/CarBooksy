using CarBooksy.Domain.Entities;
using CarBooksy.Shared.Models.Users;
using MediatR;

namespace CarBooksy.Application.Modules.Users.Commands.Create;

public class CreateUserCommand : CreateUserCommandBase, IRequest<Guid>;

public class CreateUserCommandHandler(ICreateUserDataProvider provider) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = User.Create(command);
        var id = await provider.Add(user, cancellationToken);
        return id;
    }
}