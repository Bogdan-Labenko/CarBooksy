using CarBooksy.Shared.Enums.Cars;
using CarBooksy.Shared.Models.Cars;

namespace CarBooksy.Domain.Entities;

public class Car : BaseEntity
{
    public string Make { get; private set; }
    public string Model { get; private set; }
    public int ProductionYear { get; private set; }
    public string VinCode { get; private set; }
    public string PlateNumber { get; private set; }
    public BodyType BodyType { get; private set; }
    public CarStatus Status { get; private set; }
    public Guid? CompanyId { get; private set; }
    
    private Car() {}
    
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
        IsDeleted = false;
        Make = commandBase.Make;
        Model = commandBase.Model;
        ProductionYear = commandBase.ProductionYear;
        VinCode = commandBase.VinCode;
        PlateNumber = commandBase.PlateNumber; 
        BodyType = commandBase.BodyType; 
        Status = commandBase.Status;
    }
    public void Delete() { IsDeleted = true; }
}