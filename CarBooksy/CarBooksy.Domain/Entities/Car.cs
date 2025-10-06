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