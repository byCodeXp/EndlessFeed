using API.Validation.Rules;
using FluentValidation;

namespace API.Contracts.Requests.v1
{
    public record LoginRequestV1
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
    
    public class LoginRequestV1Validation : AbstractValidator<LoginRequestV1>
    {
        public LoginRequestV1Validation()
        {
            RuleFor(request => request.Email).EmailAddress();
            RuleFor(request => request.Password).Password();
        }
    }
}