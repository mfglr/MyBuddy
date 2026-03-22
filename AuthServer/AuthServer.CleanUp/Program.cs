using AuthServer.Application;
using AuthServer.CleanUp;
using AuthServer.CleanUp.Auth;
using AuthServer.CleanUp.Cleanup;
using AuthServer.CleanUp.MassTransit;
using AuthServer.Domain;
using AuthServer.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services
    .AddAuth()
    .AddCleanup(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
