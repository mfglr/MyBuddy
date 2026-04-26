using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostService.Application.UseCases.CreatePost;
using PostService.Application.UseCases.DeletePost;
using PostService.Application.UseCases.UpdatePostContent;

namespace PostService.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class PostsController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task<CreatePostResponse> Create([FromForm] CreatePostRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdateContent(UpdatePostContentRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpDelete("{id:guid}")]
        public Task Delete(Guid id, CancellationToken cancellationToken) =>
            sender.Send(new DeletePostRequest(id), cancellationToken);
    }
}
