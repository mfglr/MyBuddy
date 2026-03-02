using Microsoft.EntityFrameworkCore;
using PostService.Domain;

namespace PostService.Infrastructure.PostgreSql
{
    internal class PostRepository(SqlContext context) : IPostRepository
    {
        public Task CreateAsync(Post post, CancellationToken cancellationToken) =>
            context.Posts.AddAsync(post, cancellationToken: cancellationToken).AsTask();

        public void Delete(Post post, CancellationToken cancellationToken) =>
            context.Posts.Remove(post);

        public Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            context.Posts.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
    }
}
