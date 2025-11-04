namespace CarBooksy.Shared.Models.Users;

public class CreateUserCommandBase
{
    public string Name { get; init; }
    public readonly int MinLengthName = 2;
    public readonly int MaxLengthName = 100;
    public string LastName { get; init; }
    public readonly int MinLengthLastName = 2;
    public readonly int MaxLengthLastName = 100;
    public string PhoneNumber { get; init; }
    public readonly int MinLengthPhone = 3;
    public readonly int MaxLengthPhone = 15;
    public string Email { get; init; }
    public DateOnly Birthday { get; init; }
    

    

    

    
}