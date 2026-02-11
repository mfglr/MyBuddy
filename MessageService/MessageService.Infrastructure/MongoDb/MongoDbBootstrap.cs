using MessageService.Domain;
using MongoDB.Driver;

namespace MessageService.Infrastructure.MongoDb
{
    internal static class MongoDbBootstrap
    {
        public static void EnsureIndexes(MongoContext context)
        {
            context.Messages.Indexes
                .CreateOne(
                    new CreateIndexModel<Message>(
                        Builders<Message>.IndexKeys.Ascending(x => x.ReceiverId).Ascending(x => x.Id),
                        new CreateIndexOptions
                        {
                            Name = "idx_receiver_id_id",
                            Background = true
                        }
                    )
                );
        }
    }
}
