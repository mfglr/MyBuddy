using UserService.Api.Auth;
using UserService.Api.MassTransit;
using UserService.Application;
using UserService.Domain;
using UserService.Infrastructure;
using UserService.Infrastructure.MongoDB;

DbConfigration.Configure();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddAuthenticationAndAuthorization(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddMassTransit(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
