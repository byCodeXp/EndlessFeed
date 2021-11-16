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

        [HttpPost(Env.Routes.Identity.REGISTER)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            return Ok(await _identityService.RegisterAsync(request));
        }
        
        [HttpPost(Env.Routes.Identity.LOGIN)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return Ok(await _identityService.LoginAsync(request));
        }

        [HttpGet(Env.Routes.Identity.GET_USER)]
        [Authorize(Roles = Env.Roles.USER + "," + Env.Roles.ADMIN)]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.Claims.FirstOrDefault(claim => claim.Type == Env.IdentityClaims.ID)?.Value;
            return Ok(await _identityService.GetUserAsync(userId));
        }
    }
}