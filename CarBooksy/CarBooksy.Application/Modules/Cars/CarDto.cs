using CarBooksy.Domain.Entities;
using CarBooksy.Shared.Models.Cars;

namespace CarBooksy.Application.Modules.Cars;

public class CarDto
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int ProductionYear { get; set; }
    public string VinCode { get; set; }
    public string PlateNumber { get; set; }
    public BodyType BodyType { get; set; }
    public CarStatus Status { get; set; }
    
}