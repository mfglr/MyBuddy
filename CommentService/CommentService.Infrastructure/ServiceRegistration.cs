using CommentService.Application;
using CommentService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommentService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration) =>
            services
                .AddDbContext<MongoContext>(
                    x => x.UseMongoDB(
                        configuration["MongoDbSettings:ConnectionString"]!,
                        configuration["MongoDbSettings:DatabaseName"]!
                    )
                )
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<ICommentRepository, CommentRepository>();
    }
}
