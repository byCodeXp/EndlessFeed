using System;
using System.Threading.Tasks;
using API.Contracts.Requests.v1;
using API.Dtos;
using API.Extensions;
using API.Services.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/comments")]
    [Authorize(Roles = Env.Roles.ALL)]
    public class CommentsControllerV1 : ControllerBase
    {
        private readonly CommentsServiceV1 _commentsServiceV1;

        public CommentsControllerV1(CommentsServiceV1 commentsServiceV1)
        {
            _commentsServiceV1 = commentsServiceV1;
        }
        
        [HttpPost("create")]
        public async Task<CommentDto> Create([FromBody] CreateCommentRequestV1 requestV1)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            return await _commentsServiceV1.CreateCommentAsync(requestV1, Guid.Parse(userId));
        }
        
        [HttpPut("update")]
        public async Task Update([FromBody] UpdateCommentRequestV1 requestV1)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            await _commentsServiceV1.UpdateCommentAsync(requestV1, Guid.Parse(userId));
        }
        
        [HttpDelete("delete/{commentId}")]
        public async Task Update([FromRoute] Guid commentId)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            await _commentsServiceV1.DeleteCommentAsync(commentId, Guid.Parse(userId));
        }
    }
}