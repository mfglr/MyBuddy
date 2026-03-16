using CommentQueryService.Shared;
using CommentQueryService.Worker.MassTransit;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddShared(builder.Configuration);

var host = builder.Build();
host.Run();
