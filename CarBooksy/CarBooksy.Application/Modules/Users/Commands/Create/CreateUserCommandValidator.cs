using CarBooksy.Application.Common.Validation;
using FluentValidation;

namespace CarBooksy.Application.Modules.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
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

        RuleFor(u => u.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Length(c => c.MinLengthPhone, c => c.MaxLengthPhone)
            .WithMessage(c => $"Phone number must be between {c.MinLengthPhone} and {c.MaxLengthPhone} characters long.")
            .Matches(@"^\+?\d{7,15}$").WithMessage("Phone number is invalid. Use digits, optional leading +.");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is invalid.");

        RuleFor(u => u.Birthday)
            .Must(d => d <= DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Birthday cannot be in the future.");
    }
}