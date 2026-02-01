using Microsoft.EntityFrameworkCore;
using PostQueryService.Domain.PostDomain;

namespace PostQueryService.Infrastructure.MsSql
{
    internal class PostRepository(MsSqlContext context) : IPostRepository
    {
        public async Task CreateAsync(Post post, CancellationToken cancellationToken) =>
            await context.Posts.AddAsync(post, cancellationToken);

        public void Delete(Post post) =>
            context.Posts.Remove(post);

        public Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            context.Posts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
