using System;
using FluentValidation;

namespace API.Contracts.Requests.v1
{
    public record CreateCommentRequestV1
    {
        public Guid PostId { get; set; }
        public string Text { get; set; }
    }

    public class CreateCommentRequestV1Validation : AbstractValidator<CreateCommentRequestV1>
    {
        public CreateCommentRequestV1Validation()
        {
            RuleFor(m => m.PostId).NotEmpty();
            RuleFor(m => m.Text).NotEmpty();
        }
    }
}