using CommentService.Application;
using CommentService.Infrastructure;
using CommetService.Workers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddAutoMapper(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

DbConfigurator.Configure(builder.Services);

var host = builder.Build();
host.Run();
