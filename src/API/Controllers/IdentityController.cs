using System.Linq;
using System.Threading.Tasks;
using API.Contracts.Requests;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IdentityService _identityService;

        public IdentityController(IdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            return Ok(await _identityService.RegisterAsync(request));
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return Ok(await _identityService.LoginAsync(request));
        }

        [HttpGet("user")]
        [Authorize(Roles = Env.Roles.ALL)]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.Claims.FirstOrDefault(claim => claim.Type == Env.IdentityClaims.ID)?.Value;
            return Ok(await _identityService.GetUserAsync(userId));
        }
    }
}