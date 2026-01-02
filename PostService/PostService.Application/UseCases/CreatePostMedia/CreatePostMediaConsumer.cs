using MassTransit;
using PostService.Application.Exceptions;
using PostService.Application.UseCases.CreatePost;
using PostService.Domain;
using PostService.Domain.Exceptions;

namespace PostService.Application.UseCases.CreatePostMedia
{
    public class CreatePostMediaConsumer(IBlobService blobService, IPostRepository postRepository, IIdentityService identityService) : IConsumer<CreatePostMediaRequest>
    {
        private readonly IBlobService _blobService = blobService;
        private readonly IPostRepository _postRepository = postRepository;
        private readonly IIdentityService _identityService = identityService;

        public async Task Consume(ConsumeContext<CreatePostMediaRequest> context)
        {
            var types = CreatePostMediaHelpers.GetMediaTypes(context.Message.Media);

            var post =
                await _postRepository.GetByIdAsync(context.Message.Id, context.CancellationToken) ??
                throw new PostNotFoundException();

            if (post.UserId != _identityService.UserId)
                throw new UnauthorizedOperationException();

            var blobNames = await _blobService.UploadAsync(Post.MediaContainerName, context.Message.Media, context.CancellationToken);

            var media = CreatePostHelpers.GenerateMedia(types, blobNames);

            try
            {
                post.AddMedia(media, context.Message.Offset);
                await _postRepository.UpdateAsync(post, context.CancellationToken);
                await context.RespondAsync(CreatePostMediaMapper.ToCreatePostMediaResponse(post.Id, media));
            }
            catch (Exception)
            {
                await _blobService.DeleteAsync(Post.MediaContainerName, blobNames, context.CancellationToken);
                throw;
            }
        }
    }
}
