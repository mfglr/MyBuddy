using ContentModerator.Application;
using ContentModerator.Infrastructure;
using ContentModerator.Worker;

var builder = Host.CreateApplicationBuilder(args);

FFmpegConfigration.Configure();

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

var host = builder.Build();
host.Run();
