using System;
using System.Threading.Tasks;
using API.Contracts.Requests;
using API.Extensions;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Env.Roles.ALL)]
    public class PostsController : ControllerBase
    {
        private readonly PostsService _postsService;

        public PostsController(PostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet("top")]
        public async Task<IActionResult> Top()
        {
            string userId = HttpContext.GetUserIdFromClaims();
            return Ok(await _postsService.GetTopPostAsync(Guid.Parse(userId)));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest request)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            return Ok(await _postsService.CreateAsync(Guid.Parse(userId), request));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePostRequest request)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            await _postsService.UpdateAsync(Guid.Parse(userId), request);
            return Ok();
        }

        [HttpDelete("delete/{postId}")]
        public async Task<IActionResult> Delete(Guid postId)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            await _postsService.DeleteAsync(Guid.Parse(userId), postId);
            return Ok();
        }
    }
}