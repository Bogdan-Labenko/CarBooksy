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
    
    public static Result<Car> Create(string make, string model, int year, string vin, string plate, BodyType bodyType, CarStatus status = CarStatus.Available)
    {
        if (string.IsNullOrWhiteSpace(make))
            return new Result<Car>(null, false, "Make is required");

        if (year < 1950 || year > DateTime.UtcNow.Year + 1)
            return new Result<Car>(null, false, "Invalid production year");

        if (string.IsNullOrWhiteSpace(vin) || vin.Length != 17)
            return new Result<Car>(null, false, "VIN must be 17 characters");

        if (string.IsNullOrWhiteSpace(plate))
            return new Result<Car>(null, false, "Plate number is required");

        return new Result<Car>(new Car
        {
            Id = Guid.CreateVersion7(),
            IsDeleted = false,
            Make = make,
            Model = model,
            ProductionYear = year,
            VinCode = vin,
            PlateNumber = plate,
            BodyType = bodyType,
            Status = status
        }, true, null);
    }
    
}

public enum BodyType
{
    Sedan,
    Coupe,
    Hatchback,
    SUV,
    Wagon,
    Cabriolet,
    Pickup,
    Minivan
}

public enum CarStatus
{
    Available,
    Rented,
    Maintenance,
    Decommissioned
}