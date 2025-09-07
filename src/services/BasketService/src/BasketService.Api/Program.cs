using BasketService.Api.Application.Services;
using BasketService.Api.Infrastructure.Data;
using LiteDB;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LitedbContext>(provider =>
{
    return new LitedbContext(new LiteDatabase(@"Infrastructure/Data/basketdb.db"), "basket");
});

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5007, o => o.Protocols = HttpProtocols.Http2);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGrpcService<BasketGrpcService>();
app.MapGrpcReflectionService();

app.Run();
