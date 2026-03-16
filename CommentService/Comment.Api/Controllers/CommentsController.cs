using CommentService.Application.UseCases.CreateComment;
using CommentService.Application.UseCases.DeleteComment;
using CommentService.Application.UseCases.UpdateCommentContent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comment.Api.Controllers
{
    [Authorize("user")]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CommentsController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task<CreateCommentResponse> Create(CreateCommentRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPut]
        public Task UpdateContent(UpdateCommentContentRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpDelete("{id:guid}")]
        public Task Delete(Guid id, CancellationToken cancellationToken) =>
            sender.Send(new DeleteCommentRequest(id), cancellationToken);
    }
}
