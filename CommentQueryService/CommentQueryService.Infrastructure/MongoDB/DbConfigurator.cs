using CommentQueryService.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace CommentQueryService.Infrastructure.MongoDB
{
    public static class DbConfigurator
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<CommentProjection>(cm =>
            {
                cm.MapIdMember(q => q.Id);
                cm.MapMember(q => q.Version);
                cm.MapMember(q => q.Comment);
                cm.MapMember(q => q.User);
                cm.MapMember(q => q.LikeCount);
                cm.MapMember(q => q.ChildCount);
            });
        }
    }
}
