using System.Linq.Dynamic.Core;
using CarBooksy.Persistance;
using CarBooksy.Shared.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace CarBooksy.Application.Modules.Users.Commands.Update;

internal interface IUpdateUserDataProvider
{
    Task Update(UpdateUserCommandBase commandBase, CancellationToken cancellationToken);
}

internal class UpdateUserDataProvider(ApplicationDbContext context) : IUpdateUserDataProvider
{
    public async Task Update(UpdateUserCommandBase commandBase, CancellationToken cancellationToken)
    {
        var user = await context.Users.FindAsync(commandBase.Id, cancellationToken);
        if (user is null)
        {
            throw new Exception("User not found");
        }
        user.Update(commandBase);
        await context.SaveChangesAsync(cancellationToken);
    }
}