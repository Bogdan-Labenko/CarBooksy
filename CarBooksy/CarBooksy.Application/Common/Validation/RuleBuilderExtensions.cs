using FluentValidation;

namespace CarBooksy.Application.Common.Validation;

public static class RuleBuilderExtensions
{
    /// <summary>
    /// Ensures that the string does not contain special characters.
    /// Only letters, digits, spaces, and dashes are allowed.
    /// </summary>
    public static IRuleBuilderOptions<T, string> NoSpecialCharacters<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches("^[A-Za-z0-9 -]+$")
            .WithMessage("{PropertyName} must contain only letters, numbers, spaces, or dashes.");
    }
}