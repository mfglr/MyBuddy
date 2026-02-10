using MessageService.Domain.ConnectionAggregate;
using MessageService.Domain.MessageAggregate;
using MessageService.Domain.MessageDeliveryAggregate;
using MessageService.Domain.MessageReadReceiptAggregate;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MessageService.Infrastructure.MongoDB
{
    internal static class DbConfiguration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<Message>(cm =>
            {
                cm.MapIdMember(x => x.Id);
                cm.MapMember(x => x.CreatedAt);
                cm.MapMember(x => x.SenderId);
                cm.MapMember(x => x.ReceiverId);
                cm.MapMember(x => x.Content);
            });
            BsonClassMap.RegisterClassMap<Connection>(cm =>
            {
                cm.MapIdMember(x => x.Id);
                cm.MapMember(x => x.Version);
                cm.MapMember(x => x.LastConnectedAt);
                cm.MapMember(x => x.ConenctionId);
            });
            BsonClassMap.RegisterClassMap<MessageDelivery>(cm =>
            {
                cm.MapIdMember(x => new { x.MessageId, x.UserId });
                cm.MapMember(x => x.CreatedAt);
            });
            BsonClassMap.RegisterClassMap<MessageReadReceipt>(cm =>
            {
                cm.MapIdMember(x => new { x.MessageId, x.UserId });
                cm.MapMember(x => x.CreatedAt);
            });
        }
    }
}
