using CarBooksy.Shared.Models.Addresses;
using CarBooksy.Shared.Models.ContactInfos;

namespace CarBooksy.Application.Modules.Companies.Queries.Get;

public class GetCompanyByIdResponse
{
    public string Name { get; init; }
    public Address Address { get; init; }
    public ContactInfo ContactInfo { get; init; }
    public string NIP { get; init; }
}