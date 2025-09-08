using BasketService.Api.Application.Services;
using BasketService.Api.Infrastructure.Data;
using LiteDB;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LitedbContext>(provider =>
{
    string databaseName = "basket";
    string connectionString = @$"{Path.Combine(Directory.GetCurrentDirectory(), databaseName + ".db")}";
    return new LitedbContext(new LiteDatabase(connectionString), "basket");
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
