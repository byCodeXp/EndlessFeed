using API.Dtos;

namespace API.Contracts.Responses
{
    public record AuthorizedResponse
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}