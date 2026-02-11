using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using RealtimeService.Domain;

namespace RealtimeService.Infrastructure.MongoDb
{
    internal static class DbConfiguration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<Connection>(cm =>
            {
                cm.MapIdMember(q => q.Id);
                cm.MapMember(q => q.LastConnectedAt);
                cm.MapMember(q => q.ConnectionId);
            });
        }
    }
}
