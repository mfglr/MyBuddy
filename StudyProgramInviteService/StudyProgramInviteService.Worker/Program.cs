using StudyProgramInviteService.Application;
using StudyProgramInviteService.Domain;
using StudyProgramInviteService.Infrastructure;
using StudyProgramInviteService.Worker.Identity;
using StudyProgramInviteService.Worker.MassTransit;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddIdentity()
    .AddMassTransit(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var host = builder.Build();
host.Run();
