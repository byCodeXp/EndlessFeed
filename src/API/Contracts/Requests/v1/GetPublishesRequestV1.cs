using FluentValidation;

namespace API.Contracts.Requests.v1;

public record GetPublishesRequestV1
{
    public int Page { get; set; }
    public int PerPage { get; set; }
}

public class GetPostsRequestV1Validation : AbstractValidator<GetPublishesRequestV1>
{
    public GetPostsRequestV1Validation()
    {
        RuleFor(request => request.Page).GreaterThan(0);
        RuleFor(request => request.PerPage).GreaterThan(0);
    }   
}