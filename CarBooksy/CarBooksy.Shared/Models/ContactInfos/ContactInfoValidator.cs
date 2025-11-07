using CarBooksy.Shared.Constraints;
using FluentValidation;

namespace CarBooksy.Shared.Models.ContactInfos;

public class ContactInfoValidator : AbstractValidator<ContactInfo>
{
    public ContactInfoValidator()
    {
        var phonePattern = $@"^\+?[0-9\s-]{{6,{ContactInfoConstraints.PhoneNumberMaxLength}}}$";
        var faxPattern = $@"^\+?[0-9\s-]{{6,{ContactInfoConstraints.FaxMaxLength}}}$";
        
        RuleFor(c => c.Phone)
            .MaximumLength(ContactInfoConstraints.PhoneNumberMaxLength).WithMessage("Phone maximum length is 20 characters.")
            .NotEmpty().WithMessage("Phone is required.")
            .Matches(phonePattern)
            .WithMessage("Phone number must contain only digits, spaces or dashes, optionally starting with '+'.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(ContactInfoConstraints.EmailMaxLength).WithMessage("Email maximum length is 100 characters.");

        RuleFor(c => c.Fax)
            .MaximumLength(20).WithMessage("Fax maximum length is 20 characters.")
            .Matches(faxPattern)
            .WithMessage("Fax number must contain only digits, spaces or dashes, optionally starting with '+'.")
            .When(c => !string.IsNullOrWhiteSpace(c.Fax));
    }
}