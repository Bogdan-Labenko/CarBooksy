using CarBooksy.Shared.Models.Addresses;
using CarBooksy.Shared.Models.ContactInfos;
using FluentValidation;

namespace CarBooksy.Application.Modules.Companies.Commands.Create;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(c => c.MinLengthName, c => c.MaxLengthName)
            .WithMessage(c => $"Name must be at least {c.MinLengthName} characters long and not exceed {c.MaxLengthName} characters.");
        
        RuleFor(c => c.NIP)
            .NotEmpty().WithMessage("NIP is required.")
            .Length(c => c.NIPLength)
            .WithMessage(c => $"NIP must be exactly {c.NIPLength} characters long.");

        RuleFor(c => c.Address)
            .NotNull().WithMessage("Address is required.")
            .SetValidator(new AddressValidator());
        
        RuleFor(c => c.ContactInfo)
            .NotNull().WithMessage("Contact info is required.")
            .SetValidator(new ContactInfoValidator());
    }
}