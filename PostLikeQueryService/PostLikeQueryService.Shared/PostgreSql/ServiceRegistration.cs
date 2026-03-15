using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using PostLikeQueryService.Shared.Model;
using PostLikeQueryService.Shared.PostgreSql.QuerRepositories;
using System.Text.Json;

namespace PostLikeQueryService.Shared.PostgreSql
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration)
        {
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                IncludeFields = true
            };

            var dataSource = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("PostgreSql"))
                .ConfigureJsonOptions(jsonSerializerOptions)
                .EnableDynamicJson()
                .Build();

            services
                .AddDbContext<SqlContext>(x => x.UseNpgsql(dataSource))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IPostUserLikeRepository, PostUserLikeRepository>()
                .AddQueryRepositories();
            return services;
        }
    }
}
