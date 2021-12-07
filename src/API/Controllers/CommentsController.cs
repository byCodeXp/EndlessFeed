using System;
using System.Threading.Tasks;
using API.Contracts.Requests;
using API.Dtos;
using API.Extensions;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Env.Roles.ALL)]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsService _commentsService;

        public CommentsController(CommentsService commentsService)
        {
            _commentsService = commentsService;
        }
        
        [HttpPost("create")]
        public async Task<CommentDto> Create([FromBody] CreateCommentRequest request)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            return await _commentsService.CreateCommentAsync(request, Guid.Parse(userId));
        }
        
        [HttpPut("update")]
        public async Task Update([FromBody] UpdateCommentRequest request)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            await _commentsService.UpdateCommentAsync(request, Guid.Parse(userId));
        }
        
        [HttpDelete("delete/{commentId}")]
        public async Task Update([FromRoute] Guid commentId)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            await _commentsService.DeleteCommentAsync(commentId, Guid.Parse(userId));
        }
    }
}