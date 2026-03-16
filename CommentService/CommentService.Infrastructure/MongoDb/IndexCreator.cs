using CommentService.Domain;
using MongoDB.Driver;

namespace CommentService.Infrastructure.MongoDb
{
    public static class IndexCreator
    {
        public static void Create(MongoContext context)
        {
            List<CreateIndexModel<Comment>> indexes = [
                new (Builders<Comment>.IndexKeys.Ascending(x => x.PostId)),
                new (Builders<Comment>.IndexKeys.Ascending(x => x.RepliedId))
            ];
            context.Comments.Indexes.CreateMany(indexes);
        }
    }
}
