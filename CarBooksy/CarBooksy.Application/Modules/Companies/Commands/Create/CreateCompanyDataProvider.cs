using CarBooksy.Domain.Entities;
using CarBooksy.Persistance;
using CarBooksy.Shared.Models.Companies;

namespace CarBooksy.Application.Modules.Companies.Commands.Create;

public interface ICreateCompanyDataProvider
{
    Task Add(Company company, CancellationToken cancellationToken);
}
public class CreateCompanyDataProvider(ApplicationDbContext context) : ICreateCompanyDataProvider
{
    public async Task Add(Company company, CancellationToken cancellationToken)
    {
        await context.Companies.AddAsync(company, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}