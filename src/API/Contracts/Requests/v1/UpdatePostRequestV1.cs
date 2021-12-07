using System;
using FluentValidation;

namespace API.Contracts.Requests.v1
{
    public record UpdatePostRequestV1
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }

    public class UpdatePostRequestV1Validation : AbstractValidator<UpdatePostRequestV1>
    {
        public UpdatePostRequestV1Validation()
        {
            RuleFor(request => request.Id).NotEmpty();
            RuleFor(request => request.Text).NotEmpty();
        }
    }
}