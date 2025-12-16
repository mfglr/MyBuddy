using PostService.Infrastructure;
using PostService.Api;

var builder = WebApplication.CreateBuilder(args);

DbConfiguration.Configure();

builder.Services.AddControllers();
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddJwt(builder.Configuration)
    .AddAutoMapper(builder.Configuration)
    .AddMassTransit(builder.Configuration);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
