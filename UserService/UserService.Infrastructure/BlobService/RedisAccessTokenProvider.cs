using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using UserService.Application;

namespace UserService.Infrastructure.BlobService
{
    internal class RedisAccessTokenProvider
    {
        private readonly ConnectionMultiplexer _muxer;
        private readonly IDatabase _database;
        private readonly IConfiguration _configuration;

        public RedisAccessTokenProvider(ConnectionMultiplexer muxer, IConfiguration configuration)
        {
            _muxer = muxer;
            _database = _muxer.GetDatabase();
            _configuration = configuration;
        }

        public string Get() => _database.StringGet(_configuration["ClientId"]).ToString();
    }
}
