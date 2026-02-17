using EnrollmentRequestService.Api.Identity;
using EnrollmentRequestService.Api.ServiceRegistrations;
using EnrollmentRequestService.Application;
using EnrollmentRequestService.Domain;
using EnrollmentRequestService.Infrastructure;
using EnrollmentRequestService.Infrastructure.PostgreSqlDb;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddIdentity(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PostgreSqlContext>();
    context.Database.Migrate();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
