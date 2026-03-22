using CommentLikeQueryService.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace CommentLikeQueryService.Infrastructure.MongoDB
{
    public static class DbConfiguration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<CommentLikeProjection>(cm =>
            {
                cm.MapIdMember(x => x.Id);
                cm.MapMember(x => x.Version);
                cm.MapMember(x => x.CommentLike);
                cm.MapMember(x => x.User);
            });
        }
    }
}
