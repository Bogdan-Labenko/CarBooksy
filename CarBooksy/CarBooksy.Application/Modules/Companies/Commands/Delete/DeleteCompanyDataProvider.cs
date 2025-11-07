using CarBooksy.Persistance;

namespace CarBooksy.Application.Modules.Companies.Commands.Delete;

public interface IDeleteCompanyDataProvider
{
    Task Delete(Guid id, CancellationToken cancellationToken);
}

public class DeleteCompanyDataProvider(ApplicationDbContext context) : IDeleteCompanyDataProvider
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