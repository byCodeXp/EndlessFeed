using FluentValidation;

namespace API.Contracts.Requests.v1;

public record CreatePostRequestV1
{
    public string Text { get; set; }
}
    
public class CreatePostRequestV1Validation : AbstractValidator<CreatePostRequestV1>
{
    public CreatePostRequestV1Validation()
    {
        RuleFor(request => request.Text).NotEmpty();
    }
}