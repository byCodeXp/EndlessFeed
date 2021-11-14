using API.Dtos;

namespace API.Contracts.Responses
{
    public record AuthorizedResponse
    {
        public UserDto User { get; set; }
    }
}