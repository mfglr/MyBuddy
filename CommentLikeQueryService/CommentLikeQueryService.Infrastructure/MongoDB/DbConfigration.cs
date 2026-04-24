using CommentLikeQueryService.Domain.CommentLikeAggregate;
using CommentLikeQueryService.Domain.UserAggregate;
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
            BsonClassMap.RegisterClassMap<CommentLike>(cm =>
            {
                cm.MapIdMember(x => x.Id);
                cm.MapMember(x => x.CreatedAt);
                cm.MapMember(x => x.User);
            });
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.MapIdMember(x => x.Id);
                cm.MapMember(x => x.Version);
                cm.MapMember(x => x.Name);
                cm.MapMember(x => x.UserName);
                cm.MapMember(x => x.Media);
            });
        }
    }
}
