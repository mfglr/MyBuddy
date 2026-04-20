using CommentQueryService.Domain.CommentAggregate;
using MongoDB.Driver;

namespace CommentQueryService.Infrastructure.MongoDB
{
    public static class IndexCreator
    {
        public static void Create(IServiceProvider serviceProvider)
        {
            var context = (MongoContext)serviceProvider.GetService(typeof(MongoContext))!;

            List<CreateIndexModel<Comment>> indexes = [
                new (Builders<Comment>.IndexKeys.Ascending(x => x.PostId).Descending(x => x.Id)),
                new (Builders<Comment>.IndexKeys.Ascending(x => x.ParentId).Descending(x => x.Id))
            ];
            context.Comments.Indexes.CreateMany(indexes);
        }
    }
}
