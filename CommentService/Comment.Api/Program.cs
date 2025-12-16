using Comment.Api;
using CommentService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddDomainServices()
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddJwt(builder.Configuration)
    .AddAutoMapper(builder.Configuration)
    .AddMassTransit(builder.Configuration);

DbConfigurator.Configure(builder.Services);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
