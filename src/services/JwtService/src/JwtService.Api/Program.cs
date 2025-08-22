
using System;
using JwtService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwtConfiguration(builder.Configuration.GetSection("Jwt"));

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
app.UseAuthentication();
app.UseAuthorization();

app.Run("http://+:5006");
