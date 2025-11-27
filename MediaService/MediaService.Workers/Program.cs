using MediaService.Application;
using MediaService.Infrastructure;
using MediaService.Workers;

var builder = Host.CreateApplicationBuilder(args);
DbConfiguration.Configure();

builder.Services
    .AddMasstransit(builder.Configuration)
    .AddApplicationServices()
    .AddInfrastructureServices();

var host = builder.Build();
host.Run();
