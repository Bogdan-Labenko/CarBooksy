using CarBooksy.Domain.Entities;
using CarBooksy.Persistance;

namespace CarBooksy.Application.Modules.Users.Commands.Create;

internal interface ICreateUserDataProvider
{
    public Task Add(User user, CancellationToken cancellationToken);
}

internal class CreateUserDataProvider(ApplicationDbContext context) : ICreateUserDataProvider
{
    public async Task Add(User user, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}