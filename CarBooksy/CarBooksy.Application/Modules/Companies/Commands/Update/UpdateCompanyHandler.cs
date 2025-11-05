using CarBooksy.Shared.Models.Companies;
using MediatR;

namespace CarBooksy.Application.Modules.Companies.Commands.Update;

public class UpdateCompanyCommand : UpdateCompanyCommandBase, IRequest;

public class UpdateCompanyHandler(IUpdateCompanyDataProvider provider) : IRequestHandler<UpdateCompanyCommand>
{
    public Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        => provider.Update(request, cancellationToken);
}