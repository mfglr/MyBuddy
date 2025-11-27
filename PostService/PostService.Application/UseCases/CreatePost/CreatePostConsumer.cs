using MassTransit;
using PostService.Domain;

namespace PostService.Application.UseCases.CreatePost
{
    internal class CreatePostConsumer(IPostRepository postRepository, IBlobService blobService) : IConsumer<CreatePostRequest>
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly IBlobService _blobService = blobService;

        public async Task Consume(ConsumeContext<CreatePostRequest> context)
        {
            var types = CreatePostConsumerHelpers.GetMediaTypes(context.Message.Media);
            var content = new Content(context.Message.Content);

            var blobNames = await _blobService.UploadAsync(Post.MediaContainerName, context.Message.Media, context.CancellationToken);

            try
            {
                var post = new Post(content, blobNames.Count);
                post.Create();
                await _postRepository.CreateAsync(post, context.CancellationToken);

                await context.RespondAsync(
                    new CreatePostResponse(
                        post.Id,
                        post.Content?.Value,
                        CreatePostConsumerHelpers.GenerateMedia(types, blobNames)
                    )
                );
            }
            catch (Exception)
            {
                await _blobService.DeleteAsync(Post.MediaContainerName, blobNames,context.CancellationToken);
                throw;
            }
        }
    }
}
