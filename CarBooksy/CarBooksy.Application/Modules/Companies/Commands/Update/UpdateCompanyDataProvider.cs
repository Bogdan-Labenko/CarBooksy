using CarBooksy.Persistance;
using CarBooksy.Shared.Models.Companies;

namespace CarBooksy.Application.Modules.Companies.Commands.Update;

internal interface IUpdateCompanyDataProvider
{
    Task Update(UpdateCompanyCommandBase command, CancellationToken cancellationToken);
}

internal class UpdateCompanyDataProvider(ApplicationDbContext context) : IUpdateCompanyDataProvider
{
    public async Task Update(UpdateCompanyCommandBase commandBase, CancellationToken cancellationToken)
    {
        var company = await context.Companies.FindAsync(commandBase.Id);
        if (company is null)
        {
            throw new Exception("Company not found");
        }
        company.Update(commandBase);
        await context.SaveChangesAsync(cancellationToken);
    }
}