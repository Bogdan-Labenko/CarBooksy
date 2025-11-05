using CarBooksy.Shared.Models;
using CarBooksy.Shared.Models.ContactInfos;

namespace CarBooksy.Application.Modules.Users.Queries.Get;

public class GetUserByIdQueryResponse
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public DateOnly Birthday { get; set; }
}