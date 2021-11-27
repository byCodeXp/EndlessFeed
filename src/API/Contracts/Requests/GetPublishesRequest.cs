using FluentValidation;

namespace API.Contracts.Requests
{
    public record GetPublishesRequest
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
    }

    public class GetPostsRequestValidation : AbstractValidator<GetPublishesRequest>
    {
        public GetPostsRequestValidation()
        {
            RuleFor(request => request.Page).GreaterThan(0);
            RuleFor(request => request.PerPage).GreaterThan(0);
        }   
    }
}