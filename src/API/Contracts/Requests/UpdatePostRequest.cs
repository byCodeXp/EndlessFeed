using System;
using FluentValidation;

namespace API.Contracts.Requests
{
    public record UpdatePostRequest
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }

    public class UpdatePostRequestValidation : AbstractValidator<UpdatePostRequest>
    {
        public UpdatePostRequestValidation()
        {
            RuleFor(request => request.Id).NotEmpty();
            RuleFor(request => request.Text).NotEmpty();
        }
    }
}