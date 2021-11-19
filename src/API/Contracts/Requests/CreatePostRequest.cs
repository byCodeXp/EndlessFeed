using FluentValidation;

namespace API.Contracts.Requests
{
    public record CreatePostRequest
    {
        public string Text { get; set; }
    }
    
    public class CreatePostRequestValidation : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidation()
        {
            RuleFor(request => request.Text).NotEmpty();
        }
    }
}