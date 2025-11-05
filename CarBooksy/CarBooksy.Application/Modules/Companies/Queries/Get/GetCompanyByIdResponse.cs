using CarBooksy.Shared.Models.Addresses;
using CarBooksy.Shared.Models.ContactInfos;

namespace CarBooksy.Application.Modules.Companies.Queries.Get;

public class GetCompanyByIdResponse
{
    public string Name { get; set; }
    public Address Address { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public string NIP { get; set; }
}