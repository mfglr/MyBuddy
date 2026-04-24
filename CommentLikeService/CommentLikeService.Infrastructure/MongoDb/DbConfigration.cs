using CommentLikeService.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace CommentLikeService.Infrastructure.MongoDb
{
    public static class DbConfiguration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<CommentLike>(cm =>
            {
                cm.MapIdMember(x => x.Id);
                cm.MapMember(x => x.SequenceId);
                cm.MapMember(x => x.CreatedAt);
            });
        }
    }
}
