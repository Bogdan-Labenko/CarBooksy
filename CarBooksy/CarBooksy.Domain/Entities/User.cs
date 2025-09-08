using CarBooksy.Shared.Models.Users;

namespace CarBooksy.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateOnly Birthday { get; set; }

    public static Result<User> Create(CreateUserCommandBase commandBase)
    {
        if (string.IsNullOrWhiteSpace(commandBase.Name))
            return new Result<User>(null, false, "Name is required");
        
        if (string.IsNullOrWhiteSpace(commandBase.LastName))
            return new Result<User>(null, false, "Last name is required");
        
        if (string.IsNullOrWhiteSpace(commandBase.PhoneNumber))
            return new Result<User>(null, false, "Phone number is required");
        
        if (string.IsNullOrWhiteSpace(commandBase.Email))
            return new Result<User>(null, false, "Email is required");
        
        if (commandBase.Birthday > DateOnly.FromDateTime(DateTime.Today))
            return new Result<User>(null, false, "Incorrect date of birth");

        return new Result<User>(new User
        {
            Id = Guid.CreateVersion7(),
            IsDeleted = false,
            Name = commandBase.Name,
            LastName = commandBase.LastName,
            PhoneNumber = commandBase.PhoneNumber,
            Email = commandBase.Email,
            Birthday = commandBase.Birthday
        }, true, "");
    }
}