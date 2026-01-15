using Comment.Api;
using CommentService.Application;
using CommentService.Domain;
using CommentService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddJwt(builder.Configuration)
    .AddMassTransit(builder.Configuration);

DbConfigurator.Configure(builder.Services);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
