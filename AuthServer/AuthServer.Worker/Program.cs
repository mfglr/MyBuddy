using AuthServer.Domain;
using AuthServer.Application;
using AuthServer.Infrastructure;
using AuthServer.Worker.Auth;
using AuthServer.Worker.MassTransit;
using Media.Models;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddAuth()
    .AddMassTransit(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
