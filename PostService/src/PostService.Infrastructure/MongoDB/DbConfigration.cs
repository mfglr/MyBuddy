using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using PostService.Domain;
using Shared.Events.SharedObjects;

namespace PostService.Infrastructure.MongoDB
{
    public static class DbConfigration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<Post>(cm =>
            {
                cm.MapIdMember(q => q.Id);
                cm.MapMember(q => q.CreatedAt);
                cm.MapMember(q => q.UpdatedAt);
                cm.MapMember(q => q.DeletedAt);
                cm.MapMember(q => q.IsDeleted);
                cm.MapMember(q => q.Version);
                cm.MapMember(q => q.UserId);
                cm.MapMember(q => q.Content);
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
                cm.MapMember(q => q.Transcodings);
                cm.MapMember(q => q.Instruction);
            });
            BsonClassMap.RegisterClassMap<MediaInstruction>(cm =>
            {
                cm.MapMember(q => q.MetadataInstruction);
                cm.MapMember(q => q.ModerationInstruction);
                cm.MapMember(q => q.ThumbnailInstructions);
                cm.MapMember(q => q.TranscodingInstructions);
            });
        }
    }
}
