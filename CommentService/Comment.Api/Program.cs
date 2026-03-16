using Comment.Api.Auth;
using Comment.Api.MassTransit;
using CommentService.Application;
using CommentService.Domain;
using CommentService.Infrastructure;
using CommentService.Infrastructure.MongoDb;

DbConfigurator.Configure();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddAuthenticationAndAuthorization(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MongoContext>();
    IndexCreator.Create(context);
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
