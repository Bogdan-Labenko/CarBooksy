using CarBooksy.Persistance;

namespace CarBooksy.Application.Modules.Users.Commands.Delete;

internal interface IDeleteUserDataProvider
{
    Task Delete(Guid id);
}

internal class DeleteUserDataProvider(ApplicationDbContext context) : IDeleteUserDataProvider
{
    public async Task Delete(Guid id)
    {
        var user = await context.Users.FindAsync(id);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        user.Delete();
        await context.SaveChangesAsync();
    }
}