using CarBooksy.Shared.Enums.Cars;

namespace CarBooksy.Shared.Models.Cars;

public class CreateCarCommandBase
{
    public string Make { get; init; }
    public readonly int MinLengthMake = 2;
    public readonly int MaxLengthMake = 50;
    public string Model { get; init; }
    public readonly int MinLengthModel = 2;
    public readonly int MaxLengthModel = 50;
    public int ProductionYear { get; init; }
    public string VinCode { get; init; }
    public readonly int LengthVinCode = 17;
    public string PlateNumber { get; init; }
    public readonly int MinLengthPlate = 5;
    public readonly int MaxLengthPlate = 12;
    public BodyType BodyType { get; init; }
    public CarStatus Status { get; init; }
}