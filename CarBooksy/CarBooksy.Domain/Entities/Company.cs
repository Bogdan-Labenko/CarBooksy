using CarBooksy.Shared.Models;

namespace CarBooksy.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    
    public Address Address { get; set; }
    
    public ContactInfo ContactInfo { get; set; }
    public string NIP { get; set; }
}