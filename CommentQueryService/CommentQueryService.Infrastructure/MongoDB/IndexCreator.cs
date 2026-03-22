using CommentQueryService.Domain;
using MongoDB.Driver;

namespace CommentQueryService.Infrastructure.MongoDB
{
    public static class IndexCreator
    {
        public static void Create(IServiceProvider serviceProvider)
        {
            var context = (MongoContext)serviceProvider.GetService(typeof(MongoContext))!;

            List<CreateIndexModel<CommentProjection>> indexes = [
                new (Builders<CommentProjection>.IndexKeys.Ascending(x => x.Comment.PostId).Descending(x => x.Id)),
                new (Builders<CommentProjection>.IndexKeys.Ascending(x => x.Comment.RepliedId).Descending(x => x.Id))
            ];
            context.Comments.Indexes.CreateMany(indexes);
        }
    }
}
