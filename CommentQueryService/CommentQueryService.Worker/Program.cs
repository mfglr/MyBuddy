using CommentQueryService.Application;
using CommentQueryService.Infrastructure;
using CommentQueryService.Infrastructure.MongoDB;
using CommentQueryService.Worker.MassTransit;

DbConfigurator.Configure();

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
