using CarBooksy.Shared.Models.ContactInfos;
using CarBooksy.Shared.Models.Users;

namespace CarBooksy.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public ContactInfo ContactInfo { get; private set; }
    public DateOnly Birthday { get; private set; }
    public Guid? CompanyId { get; private set; }
    private User() {}
    public static User Create(CreateUserCommandBase commandBase)
    {
        return new User
        {
            Id = Guid.CreateVersion7(),
            IsDeleted = false,
            Name = commandBase.Name,
            LastName = commandBase.LastName,
            ContactInfo = new ContactInfo(commandBase.PhoneNumber, commandBase.Email),
            Birthday = commandBase.Birthday
        };
    }
    public void Update(UpdateUserCommandBase commandBase)
    {
        Name = commandBase.Name;
        LastName = commandBase.LastName;
        ContactInfo = commandBase.ContactInfo;
        Birthday = commandBase.Birthday;
    }
    public void Delete() { IsDeleted = true; }
}