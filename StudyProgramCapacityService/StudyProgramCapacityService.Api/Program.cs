using StudyProgramCapacityService.Api.Identity;
using StudyProgramCapacityService.Api.MassTransit;
using StudyProgramCapacityService.Application;
using StudyProgramCapacityService.Infrastructure;
using StudyProgramCapacityService.Infrastructure.SqlCapacityManager;

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
