using System.Linq;
using System.Threading.Tasks;
using API.Contracts.Requests.v1;
using API.Controllers.Base;
using API.Services.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1;

[ApiVersion("1.0")]
public class IdentityController : ApiController
{
    private readonly IdentityServiceV1 _identityService;

    public IdentityController(IdentityServiceV1 identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestV1 request)
    {
        return Ok(await _identityService.RegisterAsync(request));
    }
        
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestV1 request)
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