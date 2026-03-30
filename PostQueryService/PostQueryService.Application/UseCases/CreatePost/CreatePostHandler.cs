using MediatR;
using PostQueryService.Domain;

namespace PostQueryService.Application.UseCases.CreatePost
{
    internal class CreatePostHandler(IPostProjectionRepository repository) : IRequestHandler<CreatePostRequest>
    {
        public async Task Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            var postProjection = await repository.GetByIdAsync(request.Id, cancellationToken);

            if(postProjection == null)
            {
                postProjection = new PostProjection(request.Id, request.Post,request.User);
                await repository.CreateAsync(postProjection, cancellationToken);
                return;
            }

            try
            {
                postProjection.UpdateUser(request.User);
                await repository.UpdateAsync(postProjection, cancellationToken);
            }
            catch (VersionOutdatedException) { }

        }
    }
}
