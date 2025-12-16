using CommentService.Infrastructure;
using CommetService.Workers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddAutoMapper(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

DbConfigurator.Configure(builder.Services);

var host = builder.Build();
host.Run();
