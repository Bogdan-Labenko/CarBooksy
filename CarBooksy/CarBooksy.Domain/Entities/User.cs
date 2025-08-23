namespace CarBooksy.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public DateTime Birthday { get; set; }
}