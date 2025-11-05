using CarBooksy.Shared.Models.Addresses;
using CarBooksy.Shared.Models.ContactInfos;

namespace CarBooksy.Shared.Models.Companies;

public class UpdateCompanyCommandBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public readonly int MinLengthName = 2;
    public readonly int MaxLengthName = 100;
    public Address Address { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public string NIP { get; set; }
    public readonly int NIPLength = 10;
}