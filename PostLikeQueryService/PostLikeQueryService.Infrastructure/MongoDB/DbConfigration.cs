using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using PostLikeQueryService.Domain.UserAggregate;

namespace PostLikeQueryService.Infrastructure.MongoDB
{
    public static class DbConfigration
    {
        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.MapIdMember(q => q.Id);
                cm.MapMember(q => q.DeletedAt);
                cm.MapMember(q => q.Version);
                cm.MapMember(q => q.Name);
                cm.MapMember(q => q.UserName);
                cm.MapMember(q => q.Media);
            });
        }
    }
}
