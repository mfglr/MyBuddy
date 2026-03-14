using UserQueryService.Api.Auth;
using UserQueryService.Shared;
using UserQueryService.Shared.MongoDB;

DbConfigration.Configure();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddAuthenticationAndAuthorization(builder.Configuration)
    .AddShared(builder.Configuration);

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();
