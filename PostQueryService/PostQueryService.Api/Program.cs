using PostQueryService.Api.Identity;
using PostQueryService.Shared;
using PostQueryService.Shared.PostgreSql;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services
    .AddIdentity(builder.Configuration)
    .AddShared(builder.Configuration);

DbInitializer.Init(builder.Services);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();