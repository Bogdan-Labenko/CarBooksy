using CarBooksy.Shared.Models;
using CarBooksy.Shared.Models.ContactInfos;

namespace CarBooksy.Application.Modules.Users.Queries.Get;

public class GetUserByIdQueryResponse
{
    public string Name { get; init; }
    public string LastName { get; init; }
    public ContactInfo ContactInfo { get; init; }
    public DateOnly Birthday { get; init; }
}