using CarBooksy.Shared.Enums.Cars;

namespace CarBooksy.Application.Modules.Cars.Queries.Get;

public class GetCarByIdQueryResponse
{
    public string Make { get; init; }
    public string Model { get; init; }
    public int ProductionYear { get; init; }
    public string VinCode { get; init; }
    public string PlateNumber { get; init; }
    public BodyType BodyType { get; init; }
    public CarStatus Status { get; init; }
}