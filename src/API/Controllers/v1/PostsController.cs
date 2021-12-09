using System;
using System.Threading.Tasks;
using API.Contracts.Requests.v1;
using API.Controllers.Base;
using API.Extensions;
using API.Services.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1;

[ApiVersion("1.0")]
public class PostsController : ApiController
{
    private readonly PostsServiceV1 _postsService;

    public PostsController(PostsServiceV1 postsService)
    {
        _postsService = postsService;
    }

    [HttpGet("{perPage}/{page}")]
    public IActionResult Get([FromRoute] GetPostsRequestV1 request)
    {
        return Ok(_postsService.GetPosts(request));
    }

    [HttpGet("current")]
    [Authorize(Roles = Env.Roles.USER)]
    public async Task<IActionResult> Current()
    {
        string userId = HttpContext.GetUserIdFromClaims();
        return Ok(await _postsService.GetCurrentPostAsync(Guid.Parse(userId)));
    }

    [HttpPost("create")]
    [Authorize(Roles = Env.Roles.USER)]
    public async Task<IActionResult> Create([FromBody] CreatePostRequestV1 requestV1)
    {
        string userId = HttpContext.GetUserIdFromClaims();
        return Ok(await _postsService.CreateAsync(Guid.Parse(userId), requestV1));
    }

    [HttpPut("update")]
    [Authorize(Roles = Env.Roles.USER)]
    public async Task<IActionResult> Update(UpdatePostRequestV1 request)
    {
        string userId = HttpContext.GetUserIdFromClaims();
        await _postsService.UpdateAsync(Guid.Parse(userId), request);
        return Ok();
    }

    [HttpDelete("delete/{postId}")]
    [Authorize(Roles = Env.Roles.USER)]
    public async Task<IActionResult> Delete(Guid postId)
    {
        string userId = HttpContext.GetUserIdFromClaims();
        await _postsService.DeleteAsync(Guid.Parse(userId), postId);
        return Ok();
    }

    [HttpPost("publish/{postId}")]
    [Authorize(Roles = Env.Roles.ADMIN)]
    public async Task<IActionResult> Publish(Guid postId)
    {
        await _postsService.PublishAsync(postId);
        return Ok();
    }
}