namespace CarBooksy.Shared.Models;

public sealed class Address
{
    public string Street { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string ZipCode { get; private set; } = null!;
    public string Country { get; private set; } = null!;

    private Address() { }

    public Address(string street, string city, string zipCode, string country)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
        Country = country;
    }
}