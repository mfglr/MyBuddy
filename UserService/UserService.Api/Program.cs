using UserService.Api.ServiceRegistrations;
using UserService.Application;
using UserService.Infrastructure;
using UserService.Infrastructure.Mongo;

var builder = WebApplication.CreateBuilder(args);

DbConfiguration.Configure();

builder.Services.AddControllers();

builder.Services
    .AddIdentity(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddMassTransit(builder.Configuration);

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

app.Run();
