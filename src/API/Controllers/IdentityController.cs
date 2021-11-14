using System.Threading.Tasks;
using API.Contracts.Requests;
using API.Services;
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
    }
}