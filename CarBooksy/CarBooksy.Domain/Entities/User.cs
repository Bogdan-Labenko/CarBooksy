using CarBooksy.Shared.Models.Users;

namespace CarBooksy.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateOnly Birthday { get; set; }

    public static User Create(CreateUserCommandBase commandBase)
    {
        return new User
        {
            Id = Guid.CreateVersion7(),
            IsDeleted = false,
            Name = commandBase.Name,
            LastName = commandBase.LastName,
            PhoneNumber = commandBase.PhoneNumber,
            Email = commandBase.Email,
            Birthday = commandBase.Birthday
        };
    }

    public void Update(UpdateUserCommandBase commandBase)
    {
        
    }
}