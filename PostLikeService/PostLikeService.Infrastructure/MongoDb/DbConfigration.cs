using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using PostLikeService.Domain;

namespace PostLikeService.Infrastructure.MongoDb
{
    public static class DbConfiguration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<PostLike>(cm =>
            {
                cm.MapIdMember(x => x.Id);
                cm.MapMember(x => x.SequenceId);
                cm.MapMember(x => x.CreatedAt);
                cm.MapMember(x => x.Version);
                cm.MapMember(x => x.IsDeleted);
                cm.MapMember(x => x.DeletedAt);
            });
        }
    }
}
