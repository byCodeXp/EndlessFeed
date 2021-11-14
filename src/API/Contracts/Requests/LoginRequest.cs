using API.Validation.Rules;
using FluentValidation;

namespace API.Contracts.Requests
{
    public record LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
    public class LoginRequestValidation : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidation()
        {
            RuleFor(request => request.Email).EmailAddress();
            RuleFor(request => request.Password).Password();
        }
    }
}