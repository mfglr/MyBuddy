using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using UserService.Domain;

namespace UserService.Infrastructure.Mongo
{
    public static class DbConfiguration
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
                cm.MapMember(q => q.IsDeleted);
                cm.MapMember(q => q.Name);
                cm.MapMember(q => q.Username);
                cm.MapMember(q => q.Gender);
                cm.MapMember(q => q.Media);
            });
        }
    }
}
