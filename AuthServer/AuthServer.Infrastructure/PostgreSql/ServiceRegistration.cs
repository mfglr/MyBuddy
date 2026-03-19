using AuthServer.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Text.Json;

namespace AuthServer.Infrastructure.PostgreSql
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSql(this IServiceCollection services,IConfiguration configuration)
        {
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                IncludeFields = true
            };

            var dataSource = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("PostgreSql"))
                .ConfigureJsonOptions(jsonSerializerOptions)
                .EnableDynamicJson()
                .Build();

            return services
                .AddDbContext<SqlContext>(x => x.UseNpgsql(dataSource))
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }
             
    }
}
