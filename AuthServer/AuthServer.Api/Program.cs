using AuthServer.Api.Auth;
using AuthServer.Api.MassTransit;
using AuthServer.Application;
using AuthServer.Domain;
using AuthServer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services
    .AddAuth(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    DbInitializer.Init(scope.ServiceProvider);
}

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.MapHealthChecks("/health");
app.MapControllers();
app.Run();
