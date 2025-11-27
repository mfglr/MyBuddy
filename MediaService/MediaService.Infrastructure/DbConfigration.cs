using MediaService.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MediaService.Infrastructure
{
    public static class DbConfiguration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<Media>(cm =>
            {
                cm.MapIdMember(q => q.Id);
                cm.MapMember(q => q.OwnerId);
                cm.MapMember(q => q.Version);
                cm.MapMember(q => q.ContainerName);
                cm.MapMember(q => q.BlobName);
                cm.MapMember(q => q.TranscodedBlobName);
                cm.MapMember(q => q.Metadata);
                cm.MapMember(q => q.Type);
                cm.MapMember(q => q.ModerationResult);
                cm.MapMember(q => q.Thumbnails);
            });
        }
    }
}
