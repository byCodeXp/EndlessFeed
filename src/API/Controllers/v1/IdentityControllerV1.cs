using System.Linq;
using System.Threading.Tasks;
using API.Attributes;
using API.Contracts.Requests.v1;
using API.Services.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [ExtendedRoute("identity", 1)]
    public class IdentityControllerV1 : ApiController
    {
        private readonly IdentityServiceV1 _identityServiceV1;

        public IdentityControllerV1(IdentityServiceV1 identityServiceV1)
        {
            _identityServiceV1 = identityServiceV1;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestV1 requestV1)
        {
            return Ok(await _identityServiceV1.RegisterAsync(requestV1));
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestV1 requestV1)
        {
            return Ok(await _identityServiceV1.LoginAsync(requestV1));
        }

        [HttpGet("user")]
        [Authorize(Roles = Env.Roles.ALL)]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.Claims.FirstOrDefault(claim => claim.Type == Env.IdentityClaims.ID)?.Value;
            return Ok(await _identityServiceV1.GetUserAsync(userId));
        }
    }
}