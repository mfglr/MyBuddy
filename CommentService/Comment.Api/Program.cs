using Comment.Api;
using CommentService.Application;
using CommentService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddAutoMapper(builder.Configuration)
    .AddMassTransit(builder.Configuration)
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

DbConfigurator.Configure(builder.Services);

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();

app.Run();
