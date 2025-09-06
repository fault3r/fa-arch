using BasketService.Api.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGrpcService<BasketGrpcService>();

app.MapGrpcReflectionService();

app.MapGet("/", () => "use gRPC client to communicate.");
app.Run("http://+:5007");
