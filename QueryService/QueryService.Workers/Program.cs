using QueryService.Application;
using QueryService.Infrastructure;
using QueryService.Workers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddAutoMapper(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
