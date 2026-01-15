using CommentService.Application.UseCases.CreateComment;
using CommentService.Application.UseCases.DeleteComment;
using CommentService.Application.UseCases.RestoreComment;
using CommentService.Application.UseCases.UpdateCommentContent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comment.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CommentsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [Authorize("user")]
        [HttpPost]
        public Task<CreateCommentResponse> Create(CreateCommentRequest request, CancellationToken cancellationToken) =>
            _sender.Send(request, cancellationToken);

        [Authorize("user")]
        [HttpPut]
        public Task UpdateContent(UpdateCommentContentRequest request, CancellationToken cancellationToken) =>
            _sender.Send(request, cancellationToken);

        [Authorize("userOrAdmin")]
        [HttpDelete("{id:guid}")]
        public Task Delete(Guid id, CancellationToken cancellationToken) =>
            _sender.Send(new DeleteCommentRequest(id), cancellationToken);

        [Authorize("admin")]
        [HttpPut]
        public Task Restore(RestoreCommentRequest request, CancellationToken cancellationToken) =>
            _sender.Send(request, cancellationToken);
    }
}
