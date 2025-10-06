namespace CarBooksy.Shared.Models.Users;

public class UpdateUserCommandBase
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public string LastName { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public DateOnly Birthday { get; init; }
}