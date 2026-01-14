using MassTransit;
using UserService.Worker.ServiceRegistrations;
using UserService.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMassTransit(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
