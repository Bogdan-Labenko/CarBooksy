using CarBooksy.Shared.Constraints;
using FluentValidation;

namespace CarBooksy.Shared.Models.Addresses;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(AddressConstraints.CityMaxLength).WithMessage("City maximum length is " + AddressConstraints.CityMaxLength);

        RuleFor(a => a.Street)
            .NotEmpty().WithMessage("Street is required.")
            .MaximumLength(AddressConstraints.StreetMaxLength).WithMessage("Street maximum length is " + AddressConstraints.StreetMaxLength);;

        RuleFor(a => a.ZipCode)
            .NotEmpty().WithMessage("Zip code is required.")
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Zip code must be in format 00-000.");

        RuleFor(a => a.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(AddressConstraints.CountryMaxLength).WithMessage("Country maximum length is " + AddressConstraints.CountryMaxLength);
    }
}