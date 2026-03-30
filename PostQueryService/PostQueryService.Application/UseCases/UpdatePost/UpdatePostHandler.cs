using MediatR;
using PostQueryService.Domain;

namespace PostQueryService.Application.UseCases.UpdatePost
{
    internal class UpdatePostHandler(IPostProjectionRepository repository) : IRequestHandler<UpdatePostRequest>
    {
        public async Task Handle(UpdatePostRequest request, CancellationToken cancellationToken)
        {
            var postProjection = await repository.GetByIdAsync(request.Id, cancellationToken);

            if(postProjection == null)
            {
                postProjection = new PostProjection(request.Id, request.Post);
                await repository.CreateAsync(postProjection, cancellationToken);
                return;
            }

            try
            {
                postProjection.UpdatePost(request.Post);
                await repository.UpdateAsync(postProjection, cancellationToken);
            }
            catch (VersionOutdatedException){}
        }
    }
}
