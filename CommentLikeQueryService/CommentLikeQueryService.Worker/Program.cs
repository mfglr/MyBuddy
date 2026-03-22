using CommentLikeQueryService.Application;
using CommentLikeQueryService.Infrastructure;
using CommentLikeQueryService.Infrastructure.MongoDB;
using CommentLikeQueryService.Worker.MassTransit;

DbConfiguration.Configure();

var builder = Host.CreateApplicationBuilder(args);
builder.Services
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
