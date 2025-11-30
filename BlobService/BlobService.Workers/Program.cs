using BlobService.Application;
using BlobService.Infrastructure;
using BlobService.Workers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMasstransit(builder.Configuration)
    .AddBlobApplicationServices()
    .AddInfrastructureServices();

var host = builder.Build();
host.Run();
