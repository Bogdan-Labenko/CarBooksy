using CarBooksy.Domain.Entities;

namespace CarBooksy.Application.Modules.Cars.Queries.GetMany;

public class GetCarsResponse
{
    public int Total { get; init; }
    public int Offset { get; init; }
    public int Limit { get; set; }
    public IList<Car> Cars { get; init; }
}