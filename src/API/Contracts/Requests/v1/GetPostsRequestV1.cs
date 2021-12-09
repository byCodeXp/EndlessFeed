using FluentValidation;

namespace API.Contracts.Requests.v1;

public record GetPostsRequestV1
{
    public int Page { get; set; }
    public int PerPage { get; set; }
};

public class GetPostsRequestV1Validation : AbstractValidator<GetPostsRequestV1>
{
    public GetPostsRequestV1Validation()
    {
        RuleFor(request => request.Page).GreaterThan(0);
        RuleFor(request => request.PerPage).GreaterThan(0);
    }   
}