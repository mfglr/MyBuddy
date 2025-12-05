using MassTransit;
using PostService.Domain;

namespace PostService.Application.UseCases.DeletePostMedia
{
    internal class DeletePostMediaConsumer(IPostRepository postRepository) : IConsumer<DeletePostMediaRequest>
    {
        private readonly IPostRepository _postRepository = postRepository;

        public async Task Consume(ConsumeContext<DeletePostMediaRequest> context)
        {
            var post =
                await _postRepository.GetByIdAsync(context.Message.Id, context.CancellationToken) ??
                throw new Exception("Post not found!");
            var deletedMedia = post.DeleMedia(context.Message.BlobName);
            await _postRepository.UpdateAsync(post, context.CancellationToken);
            await context.RespondAsync(DeletePostMediaMapper.Map(post,deletedMedia));
        }
    }
}
