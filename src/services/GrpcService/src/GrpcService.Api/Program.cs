using GrpcService.Api.Application.Interceptors;
using GrpcService.Api.Application.Services;
using GrpcService.Api.Infrastructure.Data;
using LiteDB;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LitedbContext>(provider =>
{
    string databaseName = "grpc.db";
    string collectionName = "Grpc";
    string connectionString = @$"{Path.Combine(Directory.GetCurrentDirectory(), databaseName)}";
    return new LitedbContext(new LiteDatabase(connectionString), collectionName);
});

builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<ErrorHandlingInterceptor>();
});

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

app.MapGrpcService<AppGrpcService>();
app.MapGrpcReflectionService();

app.Run();
