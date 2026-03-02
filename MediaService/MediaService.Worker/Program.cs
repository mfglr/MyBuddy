using MediaService.Application;
using MediaService.Infrastructure;
using MediaService.Infrastructure.PostgreSql;
using MediaService.Worker.Consumers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddMassTransit(builder.Configuration);

DbInitiliazer.Init(builder.Services);

var host = builder.Build();
host.Run();
