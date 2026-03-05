using UserQueryService.Shared;
using UserQueryService.Shared.MongoDB;
using UserQueryService.Worker.Consumers;

DbConfigration.Configure();

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddShared(builder.Configuration);

var host = builder.Build();
host.Run();
