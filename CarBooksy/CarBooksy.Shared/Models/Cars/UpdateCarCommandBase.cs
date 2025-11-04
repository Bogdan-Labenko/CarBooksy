using CarBooksy.Shared.Enums.Cars;

namespace CarBooksy.Shared.Models.Cars;

public class UpdateCarCommandBase
{
    public Guid Id { get; set; }
    public string Make { get; set; }
    public readonly int MinLengthMake = 2;
    public readonly int MaxLengthMake = 50;
    public string Model { get; set; }
    public readonly int MinLengthModel = 2;
    public readonly int MaxLengthModel = 50;
    public int ProductionYear { get; set; }
    public string VinCode { get; set; }
    public readonly int LengthVinCode = 17;
    public string PlateNumber { get; set; }
    public readonly int MinLengthPlate = 5;
    public readonly int MaxLengthPlate = 12;
    public BodyType BodyType { get; set; }
    public CarStatus Status { get; set; }
}