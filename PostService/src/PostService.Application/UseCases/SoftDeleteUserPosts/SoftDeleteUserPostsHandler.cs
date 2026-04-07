using MassTransit;
using MediatR;
using PostService.Domain;

namespace PostService.Application.UseCases.SoftDeleteUserPosts
{
    internal class SoftDeleteUserPostsHandler(
        IPostRepository postRepository,
        IPublishEndpoint publishEndpoint,
        SoftDeleteUserPostsMapper mapper
        
    ) : IRequestHandler<SoftDeleteUserPostsRequest>
    {
        public async Task Handle(SoftDeleteUserPostsRequest request, CancellationToken cancellationToken)
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
