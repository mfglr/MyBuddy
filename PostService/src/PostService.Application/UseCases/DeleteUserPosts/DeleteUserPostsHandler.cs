using MassTransit;
using MediatR;
using PostService.Application.UseCases.SoftDeleteUserPosts;
using PostService.Domain;

namespace PostService.Application.UseCases.DeleteUserPosts
{
    internal class DeleteUserPostsHandler(
        IPostRepository postRepository,
        IBlobService blobService,
        DeleteUserPostsMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<DeleteUserPostsRequest>
    {
        public async Task Handle(DeleteUserPostsRequest request, CancellationToken cancellationToken)
        {
            var posts = await postRepository.GetByUserIdAsync(request.UserId, cancellationToken);
            if (posts.Count == 0) return;
            
            foreach (var post in posts)
                post.Delete();

            var postsToUpdate = posts.Where(p => !p.ShouldBeDeleted);
            await postRepository.UpdateAsync(postsToUpdate, cancellationToken);

            var postsToDelete = posts.Where(p => p.ShouldBeDeleted);
            var blobNames = postsToDelete.SelectMany(x => x.BlobNames);
            await postRepository.DeleteAsync(postsToDelete, cancellationToken);
            await blobService.DeleteAsync(Post.MediaContainerName, blobNames, cancellationToken);

            var events = posts.Select(mapper.Map);
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
