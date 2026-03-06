using PostQueryService.Shared;
using PostQueryService.Worker.Consumers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddShared(builder.Configuration);

var host = builder.Build();
host.Run();
