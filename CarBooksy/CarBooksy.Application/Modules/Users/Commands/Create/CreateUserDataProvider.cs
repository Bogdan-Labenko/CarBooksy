using CarBooksy.Domain.Entities;
using CarBooksy.Persistance;

namespace CarBooksy.Application.Modules.Users.Commands.Create;

public interface ICreateUserDataProvider
{
    public Task Add(User user, CancellationToken cancellationToken);
}

public class CreateUserDataProvider(ApplicationDbContext context) : ICreateUserDataProvider
{
    public async Task Add(User user, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}