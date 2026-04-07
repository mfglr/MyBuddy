using Media.Models;
using MediaService.Application;
using MediaService.Infrastructure;
using MediaService.Infrastructure.PostgreSql;
using MediaService.Worker.Consumers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMedia()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddMassTransit(builder.Configuration);

DbInitializer.Init(builder.Services);

var host = builder.Build();
host.Run();
