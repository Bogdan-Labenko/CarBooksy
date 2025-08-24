using CarBooksy.Shared.Models.Cars;

namespace CarBooksy.Domain.Entities;

public class Car : BaseEntity
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int ProductionYear { get; set; }
    public string VinCode { get; set; }
    public string PlateNumber { get; set; }
    public BodyType BodyType { get; set; }
    
    public CarStatus Status { get; set; }
    
    public static Result<Car> Create(CreateCarCommandBase commandBase)
    {
        if (string.IsNullOrWhiteSpace(commandBase.Make))
            return new Result<Car>(null, false, "Make is required");

        if (commandBase.Year < 1950 || commandBase.Year > DateTime.UtcNow.Year + 1)
            return new Result<Car>(null, false, "Invalid production year");

        if (string.IsNullOrWhiteSpace(commandBase.Vin) || commandBase.Vin.Length != 17)
            return new Result<Car>(null, false, "VIN must be 17 characters");

        if (string.IsNullOrWhiteSpace(commandBase.Plate))
            return new Result<Car>(null, false, "Plate number is required");

        return new Result<Car>(new Car
        {
            Id = Guid.CreateVersion7(),
            IsDeleted = false,
            Make = commandBase.Make,
            Model = commandBase.Model,
            ProductionYear = commandBase.Year,
            VinCode = commandBase.Vin,
            PlateNumber = commandBase.Plate,
            BodyType = commandBase.BodyType,
            Status = commandBase.Status
        }, true, null);
    }
    
}