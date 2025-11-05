using CarBooksy.Application.Common.Validation;
using CarBooksy.Shared.Models.ContactInfos;
using FluentValidation;

namespace CarBooksy.Application.Modules.Users.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Name is required.")
            .NoSpecialCharacters()
            .Length(c => c.MinLengthName, c => c.MaxLengthName)
            .WithMessage(c => $"Name must be between {c.MinLengthName} and {c.MaxLengthName} characters long.");

        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage("LastName is required.")
            .NoSpecialCharacters()
            .Length(c => c.MinLengthLastName, c => c.MaxLengthLastName)
            .WithMessage(c => $"LastName must be between {c.MinLengthLastName} and {c.MaxLengthLastName} characters long.");

        RuleFor(u => u.ContactInfo)
            .NotNull().WithMessage("Contact info is required.")
            .SetValidator(new ContactInfoValidator());

        RuleFor(u => u.Birthday)
            .Must(d => d <= DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Birthday cannot be in the future.");
    }
}