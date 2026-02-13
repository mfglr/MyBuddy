using PostLikeQueryService.Application;
using PostLikeQueryService.Infrastructure;
using PostLikeQueryService.Infrastructure.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

DbInitiliazer.Init(builder.Services);

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();
