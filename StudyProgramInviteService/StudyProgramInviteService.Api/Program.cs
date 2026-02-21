using StudyProgramInviteService.Api.Identity;
using StudyProgramInviteService.Api.MassTransit;
using StudyProgramInviteService.Application;
using StudyProgramInviteService.Domain;
using StudyProgramInviteService.Infrastructure;
using StudyProgramInviteService.Infrastructure.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddMassTransit(builder.Configuration)
    .AddIdentity(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

DbInitiliazer.Init(builder.Services);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
