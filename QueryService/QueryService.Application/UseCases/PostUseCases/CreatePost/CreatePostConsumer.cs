using MassTransit;
using PostService.Domain;
using QueryService.Domain.PostDomain;

namespace QueryService.Application.UseCases.PostUseCases.CreatePost
{
    internal class CreatePostConsumer(IPostRepository postRepository, IUnitOfWork unitOfWork) : IConsumer<CreatePostRequest>
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Consume(ConsumeContext<CreatePostRequest> context)
        {
            var content = 
                context.Message.Content != null 
                    ? new Content(context.Message.Content.Value,context.Message.Content.ModerationResult)
                    : null;
            var media = context.Message.Media.Select(x => new Media(x.BlobName, x.Type));
            var post = new Post(context.Message.Id, content, media);
            post.Create();
            await _postRepository.CreateAsync(post, context.CancellationToken);
            await _unitOfWork.CommitAsync(context.CancellationToken);
        }
    }
}
