using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Attributes;
using API.Contracts.Requests.v1;
using API.Dtos;
using API.Extensions;
using API.Services.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [ExtendedRoute("posts", 1)]
    [Authorize(Roles = Env.Roles.ALL)]
    public class PostsControllerV1 : ApiController
    {
        private readonly PostsServiceV1 _postsServiceV1;
        private readonly CommentsServiceV1 _commentsServiceV1;

        public PostsControllerV1(PostsServiceV1 postsServiceV1, CommentsServiceV1 commentsServiceV1)
        {
            _postsServiceV1 = postsServiceV1;
            _commentsServiceV1 = commentsServiceV1;
        }

        [HttpGet("{perPage}/{page}")]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] GetPublishesRequestV1 requestV1)
        {
            return Ok(_postsServiceV1.GetPublishedPosts(requestV1));
        }

        [HttpGet("{postId}/comments")]
        [AllowAnonymous]
        public async Task<IEnumerable<CommentDto>> GetCommentsFromPost(Guid postId)
        {
            return await _commentsServiceV1.GetCommentsFromPostAsync(postId);
        }

        [HttpGet("top")]
        public async Task<IActionResult> Top()
        {
            string userId = HttpContext.GetUserIdFromClaims();
            return Ok(await _postsServiceV1.GetTopPostAsync(Guid.Parse(userId)));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestV1 requestV1)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            return Ok(await _postsServiceV1.CreateAsync(Guid.Parse(userId), requestV1));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePostRequestV1 requestV1)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            await _postsServiceV1.UpdateAsync(Guid.Parse(userId), requestV1);
            return Ok();
        }

        [HttpDelete("delete/{postId}")]
        public async Task<IActionResult> Delete(Guid postId)
        {
            string userId = HttpContext.GetUserIdFromClaims();
            await _postsServiceV1.DeleteAsync(Guid.Parse(userId), postId);
            return Ok();
        }

        [HttpPost("publish/{postId}")]
        [Authorize(Roles = Env.Roles.ADMIN)]
        public async Task<IActionResult> Publish(Guid postId)
        {
            await _postsServiceV1.PublishAsync(postId);
            return Ok();
        }
    }
}