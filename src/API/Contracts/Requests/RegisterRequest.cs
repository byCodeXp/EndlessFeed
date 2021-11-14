using API.Validation.Rules;
using FluentValidation;

namespace API.Contracts.Requests
{
    public record RegisterRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
    public class RegisterRequestValidation : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidation()
        {
            RuleFor(request => request.Name).NotEmpty();
            RuleFor(request => request.Surname).NotEmpty();
            RuleFor(request => request.Email).EmailAddress();
            RuleFor(request => request.Password).Password();
        }
    }
}