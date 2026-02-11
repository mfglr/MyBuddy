using Gateway.ServiceRegistars;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity(builder.Configuration);
builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseWebSockets();
app.MapReverseProxy();
app.Run();
