using CarBooksy.Shared.Enums.Cars;

namespace CarBooksy.Application.Modules.Cars.Queries.Get;

public class GetCarByIdQueryResponse
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int ProductionYear { get; set; }
    public string VinCode { get; set; }
    public string PlateNumber { get; set; }
    public BodyType BodyType { get; set; }
    public CarStatus Status { get; set; }
}