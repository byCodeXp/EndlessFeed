using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Contracts.Requests.v1;
using API.Controllers.Base;
using API.Dtos;
using API.Extensions;
using API.Services.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1;

[ApiVersion("1.0")]
[Authorize(Roles = Env.Roles.ALL)]
public class PostsController : ApiController
{
    private readonly PostsServiceV1 _postsService;
    private readonly CommentsServiceV1 _commentsService;

    public PostsController(PostsServiceV1 postsService, CommentsServiceV1 commentsService)
    {
        _postsService = postsService;
        _commentsService = commentsService;
    }

    [HttpGet("{perPage}/{page}")]
    [AllowAnonymous]
    public IActionResult Get([FromRoute] GetPublishesRequestV1 request)
    {
        return Ok(_postsService.GetPublishedPosts(request));
    }

    [HttpGet("{postId}/comments")]
    [AllowAnonymous]
    public async Task<IEnumerable<CommentDto>> GetCommentsFromPost(Guid postId)
    {
        return await _commentsService.GetCommentsFromPostAsync(postId);
    }

    [HttpGet("top")]
    public async Task<IActionResult> Top()
    {
        string userId = HttpContext.GetUserIdFromClaims();
        return Ok(await _postsService.GetTopPostAsync(Guid.Parse(userId)));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreatePostRequestV1 requestV1)
    {
        string userId = HttpContext.GetUserIdFromClaims();
        return Ok(await _postsService.CreateAsync(Guid.Parse(userId), requestV1));
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdatePostRequestV1 request)
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

    [HttpPost("publish/{postId}")]
    [Authorize(Roles = Env.Roles.ADMIN)]
    public async Task<IActionResult> Publish(Guid postId)
    {
        await _postsService.PublishAsync(postId);
        return Ok();
    }
}