using System;
using FluentValidation;

namespace API.Contracts.Requests
{
    public record UpdateCommentRequest
    {
        public Guid CommentId { get; set; }
        public string Text { get; set; }
    }

    public class UpdateCommentRequestValidation : AbstractValidator<UpdateCommentRequest>
    {
        public UpdateCommentRequestValidation()
        {
            RuleFor(m => m.CommentId).NotEmpty();
            RuleFor(m => m.Text).NotEmpty();
        }
    }
}