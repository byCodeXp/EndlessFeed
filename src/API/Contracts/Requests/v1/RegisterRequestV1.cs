using API.Validation.Rules;
using FluentValidation;

namespace API.Contracts.Requests.v1;

public record RegisterRequestV1
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
    
public class RegisterRequestV1Validation : AbstractValidator<RegisterRequestV1>
{
    public RegisterRequestV1Validation()
    {
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.Surname).NotEmpty();
        RuleFor(request => request.Email).EmailAddress();
        RuleFor(request => request.Password).Password();
    }
}