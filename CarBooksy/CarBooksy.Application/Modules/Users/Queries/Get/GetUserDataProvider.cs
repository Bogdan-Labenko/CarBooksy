using CarBooksy.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarBooksy.Application.Modules.Users.Queries.Get;

internal interface IGetUserDataProvider
{
    Task<GetUserByIdQueryResponse?> Get(Guid id, CancellationToken cancellationToken);
}

internal class GetUserDataProvider(ApplicationDbContext context) : IGetUserDataProvider
{
    public async Task<GetUserByIdQueryResponse?> Get(Guid id, CancellationToken cancellationToken)
        => await context.Users
            .AsNoTracking()
            .Where(u => u.Id == id && u.IsDeleted == false)
            .Select(u => new GetUserByIdQueryResponse()
            {
                Name = u.Name,
                LastName = u.LastName,
                ContactInfo = u.ContactInfo,
                Birthday = u.Birthday
            })
            .FirstOrDefaultAsync(cancellationToken);
}