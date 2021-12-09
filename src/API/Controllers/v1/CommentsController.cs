using System;
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
[Authorize(Roles = Env.Roles.USER)]
public class CommentsController : ApiController
{
    private readonly CommentsServiceV1 _commentsService;

    public CommentsController(CommentsServiceV1 commentsService)
    {
        _commentsService = commentsService;
    }
        
    [HttpPost("create")]
    public async Task<CommentDto> Create([FromBody] CreateCommentRequestV1 request)
    {
        string userId = HttpContext.GetUserIdFromClaims();
        return await _commentsService.CreateCommentAsync(request, Guid.Parse(userId));
    }
        
    [HttpPut("update")]
    public async Task Update([FromBody] UpdateCommentRequestV1 request)
    {
        string userId = HttpContext.GetUserIdFromClaims();
        await _commentsService.UpdateCommentAsync(request, Guid.Parse(userId));
    }
        
    [HttpDelete("{commentId}/delete")]
    public async Task<IActionResult> Delete([FromRoute] Guid commentId)
    {
        string userId = HttpContext.GetUserIdFromClaims();
        await _commentsService.DeleteCommentAsync(commentId, Guid.Parse(userId));
        return Ok();
    }

    [HttpPost("{commentId}/block")]
    public async Task<IActionResult> Block(Guid commentId)
    {
        await _commentsService.BlockCommentByIdAsync(commentId);
        return Ok();
    }
}