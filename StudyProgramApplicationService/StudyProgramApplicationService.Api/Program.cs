using StudyProgramApplicationService.Api.Identity;
using StudyProgramApplicationService.Api.MassTransit;
using StudyProgramApplicationService.Application;
using StudyProgramApplicationService.Domain;
using StudyProgramApplicationService.Infrastructure;
using StudyProgramApplicationService.Infrastructure.PostgreSqlDb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddIdentity(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

DbInitiliazer.Init(builder.Services);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
