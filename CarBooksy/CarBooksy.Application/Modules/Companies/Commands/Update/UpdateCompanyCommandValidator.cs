using CarBooksy.Shared.Models.Addresses;
using CarBooksy.Shared.Models.ContactInfos;
using FluentValidation;

namespace CarBooksy.Application.Modules.Companies.Commands.Update;

public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(c => c.MinLengthName, c => c.MaxLengthName)
            .WithMessage(c =>
                $"Name must be at least {c.MinLengthName} characters long and not exceed {c.MaxLengthName} characters");
        
        RuleFor(c => c.Address)
            .NotNull().WithMessage("Address is required.")
            .SetValidator(new AddressValidator());

        RuleFor(c => c.ContactInfo)
            .NotNull().WithMessage("Contact info is required.")
            .SetValidator(new ContactInfoValidator()); 
    }
}