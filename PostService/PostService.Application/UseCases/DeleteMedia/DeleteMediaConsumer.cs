using MassTransit;
using PostService.Domain;

namespace PostService.Application.UseCases.DeleteMedia
{
    internal class DeleteMediaConsumer(IPostRepository postRepository) : IConsumer<DeleteMediaRequest>
    {
        private readonly IPostRepository _postRepository = postRepository;

        public async Task Consume(ConsumeContext<DeleteMediaRequest> context)
        {
            var post =
                await _postRepository.GetByIdAsync(context.Message.Id, context.CancellationToken) ??
                throw new Exception("Post not found!");
            var media = post.DeleMedia(context.Message.BlobName);
            await _postRepository.UpdateAsync(post, context.CancellationToken);
            await context.RespondAsync(new DeleteMediaResponse(media.ContainerName, media.BlobNames));
        }
    }
}
