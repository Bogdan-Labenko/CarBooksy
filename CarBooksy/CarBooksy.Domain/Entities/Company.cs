using CarBooksy.Shared.Models;

namespace CarBooksy.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    
    public string Address { get; set; }
    
    public ContactInfo ContactInfo { get; set; }
    
    public string NIP { get; set; }
    
    public IList<User> Users { get; set; }
    
    public IList<Car> Cars { get; set; }
    
}