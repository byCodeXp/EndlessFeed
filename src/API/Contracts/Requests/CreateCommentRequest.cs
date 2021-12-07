using System;
using FluentValidation;

namespace API.Contracts.Requests
{
    public record CreateCommentRequest
    {
        public Guid PostId { get; set; }
        public string Text { get; set; }
    }

    public class CreateCommentRequestValidation : AbstractValidator<CreateCommentRequest>
    {
        public CreateCommentRequestValidation()
        {
            RuleFor(m => m.PostId).NotEmpty();
            RuleFor(m => m.Text).NotEmpty();
        }
    }
}