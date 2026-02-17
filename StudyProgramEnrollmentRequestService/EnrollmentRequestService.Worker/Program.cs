using EnrollmentRequestService.Application;
using EnrollmentRequestService.Infrastructure;
using EnrollmentRequestService.Worker.Identity;
using EnrollmentRequestService.Worker.MassTransit;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddIdentity()
    .AddConsumers(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
