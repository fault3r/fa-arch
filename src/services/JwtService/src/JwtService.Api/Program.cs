using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/token", () =>
{
    return Results.Ok(new { token = "token" });
});

app.UseHttpsRedirection();

app.Run("http://+:5006");
