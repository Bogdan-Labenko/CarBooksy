namespace CarBooksy.Shared.Models.Cars;

public class CreateCarCommandBase
{
    public string Make { get; init; }
    public string Model { get; init; }
    public int Year { get; init; }
    public string Vin { get; init; }
    public string Plate { get; init; }
    public BodyType BodyType { get; init; }
    public CarStatus Status { get; init; }
}