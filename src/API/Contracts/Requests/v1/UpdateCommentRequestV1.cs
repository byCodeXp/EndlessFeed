using System;
using FluentValidation;

namespace API.Contracts.Requests.v1
{
    public record UpdateCommentRequestV1
    {
        public Guid CommentId { get; set; }
        public string Text { get; set; }
    }

    public class UpdateCommentRequestV1Validation : AbstractValidator<UpdateCommentRequestV1>
    {
        public UpdateCommentRequestV1Validation()
        {
            RuleFor(m => m.CommentId).NotEmpty();
            RuleFor(m => m.Text).NotEmpty();
        }
    }
}