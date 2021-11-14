using System.Threading.Tasks;
using API.Contracts.Requests;
using API.Contracts.Responses;
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
            AuthorizedResponse result = await _identityService.RegisterAsync(request);
            if (result == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(result);
        }
        
        [HttpPost(Env.Routes.Identity.LOGIN)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            AuthorizedResponse result = await _identityService.LoginAsync(request);
            if (result == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(result);
        }
    }
}