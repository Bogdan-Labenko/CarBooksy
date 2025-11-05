using CarBooksy.Domain.Entities;
using CarBooksy.Shared.Models.Companies;
using MediatR;

namespace CarBooksy.Application.Modules.Companies.Commands.Create;

public class CreateCompanyCommand : CreateCompanyCommandBase, IRequest<Guid>;

public class CreateCompanyHandler(ICreateCompanyDataProvider provider) : IRequestHandler<CreateCompanyCommand, Guid>
{
    public async Task<Guid> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
        var company = Company.Create(command);
        await provider.Add(company, cancellationToken);
        return company.Id;
    }
}