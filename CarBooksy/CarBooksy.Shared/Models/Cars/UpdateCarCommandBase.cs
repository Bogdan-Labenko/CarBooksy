namespace CarBooksy.Shared.Models.Cars;

public class UpdateCarCommandBase
{
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int ProductionYear { get; set; }
    public string VinCode { get; set; }
    public string PlateNumber { get; set; }
    public BodyType BodyType { get; set; }
    public CarStatus Status { get; set; }
}