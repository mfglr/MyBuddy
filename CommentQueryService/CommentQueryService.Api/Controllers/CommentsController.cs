using CommentQueryService.Application.UseCases;
using CommentQueryService.Application.UseCases.GetByParentId;
using CommentQueryService.Application.UseCases.GetByPostId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommentQueryService.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CommentsController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public Task<IEnumerable<CommentResponse>> GetByPostId(GetByPostIdRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);

        [HttpPost]
        public Task<IEnumerable<CommentResponse>> GetByParentId(GetByParentIdRequest request, CancellationToken cancellationToken) =>
            sender.Send(request, cancellationToken);
    }
}
