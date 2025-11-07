using CarBooksy.Persistance;

namespace CarBooksy.Application.Modules.Companies.Commands.Delete;

internal interface IDeleteCompanyDataProvider
{
    Task Delete(Guid id, CancellationToken cancellationToken);
}

internal class DeleteCompanyDataProvider(ApplicationDbContext context) : IDeleteCompanyDataProvider
{
    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var company = await context.Companies.FindAsync(id, cancellationToken);
        if (company is null)
        {
            throw new Exception("Company not found");
        }

        company.Delete();
        await context.SaveChangesAsync(cancellationToken);
    }
}