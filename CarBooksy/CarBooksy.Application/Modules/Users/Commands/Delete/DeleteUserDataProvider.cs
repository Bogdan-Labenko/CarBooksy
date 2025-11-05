using CarBooksy.Persistance;

namespace CarBooksy.Application.Modules.Users.Commands.Delete;

public interface IDeleteUserDataProvider
{
    Task Delete(Guid id);
}

public class DeleteUserDataProvider(ApplicationDbContext context) : IDeleteUserDataProvider
{
    public async Task Delete(Guid id)
    {
        var user = await context.Users.FindAsync(id);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        user.IsDeleted = true;
        await context.SaveChangesAsync();
    }
}