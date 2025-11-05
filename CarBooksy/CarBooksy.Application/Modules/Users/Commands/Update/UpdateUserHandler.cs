using CarBooksy.Shared.Models.Users;
using MediatR;

namespace CarBooksy.Application.Modules.Users.Commands.Update;

public class UpdateUserCommand : UpdateUserCommandBase, IRequest;

public class UpdateUserHandler(IUpdateUserDataProvider provider) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await provider.Update(request, cancellationToken);
    }
}