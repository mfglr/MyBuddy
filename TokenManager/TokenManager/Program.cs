using StackExchange.Redis;
using TokenManager;
using TokenManager.Abstracts;
using TokenManager.Concretes;

var builder = Host.CreateApplicationBuilder(args);

var authOptions = builder.Configuration.GetSection("IdentityServerOpitons").Get<IdentityServerOpitons>()!;
builder.Services
    .AddSingleton(authOptions)
    .AddSingleton<IHealthChecker, IdentityServerHealthChecker>()
    .AddSingleton(ConnectionMultiplexer.Connect(builder.Configuration["Redis:Host"]!))
    .AddSingleton<IAccessTokenCache, RedisAccessTokenCache>()
    .AddSingleton<IAccessTokenProvider, IdentityServerAccessTokenProvider>()
    .AddHostedService<Worker>();

var host = builder.Build();
host.Run();
