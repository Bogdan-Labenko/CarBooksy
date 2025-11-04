using CarBooksy.Application.Common.Validation;
using FluentValidation;

namespace CarBooksy.Application.Modules.Cars.Commands.Create;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(c => c.Make)
            .NotEmpty()
            .NoSpecialCharacters()
            .Length(c => c.MinLengthMake, c => c.MaxLengthMake)
            .WithMessage(c => $"Make must be between {c.MinLengthMake} and {c.MaxLengthMake} characters long.");
        RuleFor(c => c.Model)
            .NotEmpty()
            .NoSpecialCharacters()
            .Length(c => c.MinLengthModel, c => c.MaxLengthModel)
            .WithMessage(c => $"Model must be between {c.MinLengthModel} and {c.MaxLengthModel} characters long.");
        RuleFor(c => c.PlateNumber)
            .NotEmpty()
            .NoSpecialCharacters()
            .Length(c => c.MinLengthPlate, c => c.MaxLengthPlate)
            .WithMessage(c => $"Plate number must be between {c.MinLengthPlate} and {c.MaxLengthPlate} characters long.");
        RuleFor(c => c.VinCode)
            .NotEmpty()
            .NoSpecialCharacters()
            .Length(c => c.LengthVinCode)
            .WithMessage(c => $"Vin code must be {c.LengthVinCode} characters long.");
        RuleFor(c => c.ProductionYear)
            .NotEmpty()
            .InclusiveBetween(1900, DateTime.UtcNow.Year + 1)
            .WithMessage($"Production year must be between 1900 and {DateTime.UtcNow.Year + 1}.");
    }
}