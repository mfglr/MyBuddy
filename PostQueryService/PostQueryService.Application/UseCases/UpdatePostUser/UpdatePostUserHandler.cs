using MediatR;
using PostQueryService.Application.UseCases.UpsertPost;
using PostQueryService.Domain.PostProjectionAggregate;

namespace PostQueryService.Application.UseCases.UpdatePostUser
{
    internal class UpdatePostUserHandler(IPostProjectionRepository repository) : IRequestHandler<UpsertPostRequest>
    {
        public Task Handle(UpsertPostRequest request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
