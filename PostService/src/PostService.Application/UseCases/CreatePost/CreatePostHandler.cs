using MassTransit;
using MediatR;
using PostService.Domain;

namespace PostService.Application.UseCases.CreatePost
{
    internal class CreatePostHandler(
        IPostRepository postRepository,
        IBlobService blobService,
        IAuthService authService,
        IPublishEndpoint publishEndpoint,
        CreatePostMapper mapper,
        MediaTypeExtractor mediaTypeExtractor,
        MediaGenerator mediaGenerator
    ) : IRequestHandler<CreatePostRequest, CreatePostResponse>
    {
        public async Task<CreatePostResponse> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            var content = request.Content != null ? new Content(request.Content) : null;

            var types = mediaTypeExtractor.GetMediaTypes(request.Media);
            var blobNames = await blobService.UploadAsync(Post.MediaContainerName, request.Media, cancellationToken);
            var media = mediaGenerator.Generate(types, blobNames);
            try
            {
                var post = new Post(authService.UserId, content, media);
                await postRepository.CreateAsync(post, cancellationToken);

                var @event = mapper.Map(post);
                await publishEndpoint.Publish(@event,cancellationToken);
                
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
