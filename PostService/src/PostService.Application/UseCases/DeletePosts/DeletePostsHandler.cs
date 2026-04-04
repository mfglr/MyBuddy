using MassTransit;
using MediatR;
using PostService.Domain;

namespace PostService.Application.UseCases.DeletePosts
{
    internal class DeletePostsHandler(
        IPostRepository postRepository,
        IPublishEndpoint publishEndpoint,
        DeletePostsMapper mapper
        
    ) : IRequestHandler<DeletePostsRequest>
    {
        public async Task Handle(DeletePostsRequest request, CancellationToken cancellationToken)
        {
            var posts = await postRepository.GetByUserIdAsync(request.UserId, cancellationToken);
            if (posts.Count == 0) return;
            
            foreach (var post in posts)
                post.Delete();
            await postRepository.UpdateAsync(posts, cancellationToken);

            var events = posts.Select(mapper.Map);
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
