using CommentQueryService.Shared.Model;
using CommentQueryService.Shared.PostgreSql.QuerRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Text.Json;

namespace CommentQueryService.Shared.PostgreSql
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
                .AddScoped<ICommentRepository, CommentRepository>()
                .AddQueryRepositories();
            return services;
        }
    }
}
