using System;
using System.Threading.Tasks;
using API.Contracts.Requests.v1;
using API.Controllers.Base;
using API.Services.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1;

[ApiVersion("1.0")]
public class PublishesController : ApiController
{
    private readonly PostsServiceV1 _postsService;

    public PublishesController(PostsServiceV1 postsService)
    {
        _postsService = postsService;
    }

    [HttpGet("{perPage}/{page}")]
    public IActionResult Get([FromRoute] GetPostsRequestV1 request)
    {
        return Ok(_postsService.GetPublishedPosts(request));
    }

    [HttpGet("{publishId}/comments")]
    public IActionResult Comments([FromRoute] Guid publishId)
    {
        return Ok(_postsService.GetPublishedPostCommentsAsync(publishId));
    }

    [Authorize(Roles = Env.Roles.ADMIN)]
    [HttpPost("{publishId}/block")]
    public async Task<IActionResult> BlockPublish(Guid publishId)
    {
        return Ok();
    }
}