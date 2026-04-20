using CommentQueryService.Domain.CommentAggregate;
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
            BsonClassMap.RegisterClassMap<Comment>(cm =>
            {
                cm.MapIdMember(q => q.Id);
                cm.MapMember(q => q.CreatedAt);
                cm.MapMember(q => q.UpdatedAt);
                cm.MapMember(q => q.IsDeleted);
                cm.MapMember(q => q.Version);
                cm.MapMember(q => q.UserId);
                cm.MapMember(q => q.PostId);
                cm.MapMember(q => q.ParentId);
                cm.MapMember(q => q.RepliedId);
                cm.MapMember(q => q.Content);
                cm.MapMember(q => q.ProcessedVersions);
                cm.MapMember(q => q.User);
                cm.MapMember(q => q.LikeCount);
                cm.MapMember(q => q.ChildCount);
            });
        }
    }
}
