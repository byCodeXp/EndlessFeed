using API.Dtos;

namespace API.Contracts.Responses.v1
{
    public record AuthorizedResponseV1
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}