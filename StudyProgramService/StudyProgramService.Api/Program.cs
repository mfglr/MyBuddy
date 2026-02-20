using StudyProgramService.Api.Identity;
using StudyProgramService.Api.MassTransit;
using StudyProgramService.Application;
using StudyProgramService.Infrastructure;
using StudyProgramService.Infrastructure.PostgreSqlDb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddMassTransit(builder.Configuration)
    .AddIdentity(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

DbInitiliazer.Init(builder.Services);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
