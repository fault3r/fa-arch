
using System;
using JwtService.Api.JwtAuthentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddJwtConfiguration(builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/Token", () =>
{
    var settings = builder.Configuration.GetSection("Jwt");
    var token = JwtToken.Generate("fault3r.", new JwtSettings
    {
        Key = settings["Key"],
        Issuer = settings["Issuer"],
        Audience = settings["Audience"],
    });
    return Results.Ok(new { Token = token });
});

app.UseHttpsRedirection();

app.Run("http://+:5006");
