using System.Linq.Dynamic.Core;
using CarBooksy.Application.Modules.Cars.Queries.Get;
using CarBooksy.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarBooksy.Application.Modules.Companies.Queries.Get;

internal interface IGetCompanyDataProvider
{
    Task<GetCompanyByIdResponse?> Get(Guid id, CancellationToken cancellationToken);
}

internal class GetCompanyDataProvider(ApplicationDbContext context) : IGetCompanyDataProvider
{
    public async Task<GetCompanyByIdResponse?> Get(Guid id, CancellationToken cancellationToken)
        => await context.Companies
            .AsNoTracking()
            .Where(c => c.Id == id && c.IsDeleted == false)
            .Select(c => new GetCompanyByIdResponse()
            {
                Name = c.Name,
                Address = c.Address,
                ContactInfo = c.ContactInfo,
                NIP = c.NIP
            })
            .FirstOrDefaultAsync(cancellationToken);
}