using MassTransit;
using MediatR;
using PostService.Domain;

namespace PostService.Application.UseCases.CreatePost
{
    internal class CreatePostHandler(IUnitOfWork unitOfWork, IPostRepository postRepository, IBlobService blobService, CreatePostMapper mapper, IIdentityService identityService, IPublishEndpoint publishEndpoint) : IRequestHandler<CreatePostRequest, CreatePostResponse>
    {
        public async Task<CreatePostResponse> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            var types = CreatePostHelpers.GetMediaTypes(request.Media);
            var content = request.Content != null ? new Content(request.Content) : null;
            var blobNames = await blobService.UploadAsync(Post.MediaContainerName, request.Media, cancellationToken);
            var media = CreatePostHelpers.GenerateMedia(types, blobNames);
            try
            {
                var post = new Post(identityService.UserId, content, media);
                await postRepository.CreateAsync(post, cancellationToken);

                var @event = mapper.Map(post);
                await publishEndpoint.Publish(@event,cancellationToken);
              
                await unitOfWork.CommitAsync(cancellationToken);

                return new(post.Id);
            }
            catch (Exception)
            {
                await blobService.DeleteAsync(Post.MediaContainerName, blobNames, cancellationToken);
                throw;
            }
        }
    }
}
