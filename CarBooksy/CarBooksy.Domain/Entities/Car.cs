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
    
    public static Car Create(CreateCarCommandBase commandBase)
    {
        /*if (string.IsNullOrWhiteSpace(commandBase.Make))
            return new Result<Car>(null, false, "Make is required");

        if (commandBase.ProductionYear < 1950 || commandBase.ProductionYear > DateTime.UtcNow.Year + 1)
            return new Result<Car>(null, false, "Invalid production year");

        if (string.IsNullOrWhiteSpace(commandBase.VinCode) || commandBase.VinCode.Length != 17)
            return new Result<Car>(null, false, "VIN must be 17 characters");

        if (string.IsNullOrWhiteSpace(commandBase.PlateNumber))
            return new Result<Car>(null, false, "Plate number is required");*/

        return new Car
        {
            Id = Guid.CreateVersion7(),
            IsDeleted = false,
            Make = commandBase.Make,
            Model = commandBase.Model,
            ProductionYear = commandBase.ProductionYear,
            VinCode = commandBase.VinCode,
            PlateNumber = commandBase.PlateNumber,
            BodyType = commandBase.BodyType,
            Status = commandBase.Status
        };
    }

    public void Update(UpdateCarCommandBase commandBase)
    {
        /*if (string.IsNullOrWhiteSpace(commandBase.Make))
            return new Result( false, "Make is required");

        if (commandBase.ProductionYear < 1950 || commandBase.ProductionYear > DateTime.UtcNow.Year + 1)
            return new Result(false, "Invalid production year");

        if (string.IsNullOrWhiteSpace(commandBase.VinCode) || commandBase.VinCode.Length != 17)
            return new Result(false, "VIN must be 17 characters");

        if (string.IsNullOrWhiteSpace(commandBase.PlateNumber))
            return new Result(false, "Plate number is required");*/
        
        Id = commandBase.Id;
        IsDeleted = false;
        Make = commandBase.Make;
        Model = commandBase.Model;
        ProductionYear = commandBase.ProductionYear;
        VinCode = commandBase.VinCode;
        PlateNumber = commandBase.PlateNumber; 
        BodyType = commandBase.BodyType; 
        Status = commandBase.Status;
    }
    private Car() {}
}