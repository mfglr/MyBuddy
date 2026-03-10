using MediaService.Application;
using MediaService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Text.Json;

namespace MediaService.Infrastructure.PostgreSql
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
                .AddDbContext<SqlContext>(options => options.UseNpgsql(dataSource))
                .AddScoped<IMediaRepository, MediaRepository>()
                .AddScoped<IUnitOfWork,UnitOfWork>();
            return services;
        }
    }
}
