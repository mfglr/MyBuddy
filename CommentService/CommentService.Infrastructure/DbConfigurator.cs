using CommentService.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace CommentService.Infrastructure
{
    public static class DbConfigurator
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<Comment>(cm =>
            {
                cm.MapIdMember(x => x.Id);
                cm.MapMember(x => x.CreatedAt);
                cm.MapMember(x => x.UpdatedAt);
                cm.MapMember(x => x.IsDeleted);
                cm.MapMember(x => x.Version);
                cm.MapMember(x => x.UserId);
                cm.MapMember(x => x.PostId);
                cm.MapMember(x => x.ParentId);
                cm.MapMember(x => x.RepliedId);
                cm.MapMember(x => x.Content);
            });
        }
    }
}
