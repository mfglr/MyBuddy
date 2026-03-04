using MediaService.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MediaService.Infrastructure.MongoDB
{
    internal static class DbConfigration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<MediaList>(cm =>
            {
                cm.MapIdMember(q => q.Id);
                cm.MapMember(q => q.Items);
            });
        }
    }
}
