using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using UserQueryService.Shared.Model;

namespace UserQueryService.Shared.MongoDB
{
    public static class DbConfigration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.MapIdMember(q => q.Id);
                cm.MapMember(q => q.CreatedAt);
                cm.MapMember(q => q.UpdatedAt);
                cm.MapMember(q => q.Version);
                cm.MapMember(q => q.Name);
                cm.MapMember(q => q.UserName);
                cm.MapMember(q => q.Gender);
                cm.MapMember(q => q.Media);
            });
            BsonClassMap.RegisterClassMap<Media>(cm =>
            {
                cm.MapMember(q => q.ContainerName);
                cm.MapMember(q => q.BlobName);
                cm.MapMember(q => q.Type);
                cm.MapMember(q => q.Metadata);
                cm.MapMember(q => q.ModerationResult);
                cm.MapMember(q => q.Thumbnails);
            });
        }
    }
}
