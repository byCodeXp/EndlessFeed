using FluentValidation;

namespace API.Validation.Rules;

public static class RuleBuilderExtensions
{
    public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 8)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Password cannot be empty")
            .MinimumLength(minimumLength).WithMessage($"Minimum password length {minimumLength}")
            .Matches("[A-Z]").WithMessage("Password must contain one more upper case letter")
            .Matches("[a-z]").WithMessage("Password must contain one more lower case letter")
            .Matches("[0-9]").WithMessage("Password must contain one digit");
    }
}